using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Client
{
	public class ReminderStorageWebApiClient : IReminderStorage
	{
		private string _baseWebApiUrl;
		private HttpClient _httpClient;

		public ReminderStorageWebApiClient(string baseWebApiUrl)
		{
			_baseWebApiUrl = baseWebApiUrl;
			_httpClient = HttpClientFactory.Create();
		}

		public int Count
		{
			get
			{
				var httpResponseMessage = CallWebApi("HEAD", "/api/reminders", null);
				if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
				{
					throw GetException(httpResponseMessage);
				}

				const string totalCountHeaderName = "X-Total-Count";
				if (!httpResponseMessage.Headers.Contains(totalCountHeaderName))
				{
					throw new Exception($"There is no expected header '{totalCountHeaderName}' found");
				}

				string xTotalCountHeader = httpResponseMessage.Headers
					.GetValues(totalCountHeaderName)
					.First();

				return int.Parse(xTotalCountHeader);
			}
		}

		public Guid Add(ReminderItemRestricted reminder)
		{
			var result = CallWebApi(
				"POST",
				"/api/reminders",
				JsonConvert.SerializeObject(new ReminderItemCreateModel(reminder)));

			if (result.StatusCode != System.Net.HttpStatusCode.Created)
			{
				throw GetException(result);
			}

			return JsonConvert
				.DeserializeObject<ReminderItemGetModel>(
					result.Content.ReadAsStringAsync().Result)
				.Id;
		}

		public ReminderItem Get(Guid id)
		{
			var result = CallWebApi(
				"GET",
				 $"/api/reminders/{id}");

			if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}

			if (result.StatusCode != System.Net.HttpStatusCode.OK)
			{
				throw GetException(result);
			}

			var reminderItemGetModel = JsonConvert.DeserializeObject<ReminderItemGetModel>(
				result.Content.ReadAsStringAsync().Result);

			return reminderItemGetModel.ToReminderItem();
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			var queryParams = new List<KeyValuePair<string, string>>();
			queryParams.Add(new KeyValuePair<string, string>("[filter]status", ((int)status).ToString()));

			var httpResponseMessage = CallWebApi("GET", "/api/reminders" + BuildQueryString(queryParams));

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
			{
				throw GetException(httpResponseMessage);
			}

			var list = JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(
				httpResponseMessage.Content.ReadAsStringAsync().Result);

			if (list == null)
				throw new Exception($"Body cannot be parsed as List<ReminderItemGetModel>.");

			return list
				.Select(m => m.ToReminderItem())
				.ToList();
		}

		public List<ReminderItem> Get(int count, int startPostion)
		{
			var queryParams = new List<KeyValuePair<string, string>>();

			if (count > 0)
				queryParams.Add(new KeyValuePair<string, string>("[paging]count", count.ToString()));

			if (startPostion > 0)
				queryParams.Add(new KeyValuePair<string, string>("[paging]startPostion", startPostion.ToString()));

			var httpResponseMessage = CallWebApi("GET", "/api/reminders" + BuildQueryString(queryParams));

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
			{
				throw GetException(httpResponseMessage);
			}

			var list = JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(
				httpResponseMessage.Content.ReadAsStringAsync().Result);

			if (list == null)
				throw new Exception($"Body cannot be parsed as List<ReminderItemGetModel>.");

			return list
				.Select(m => m.ToReminderItem())
				.ToList();
		}

		public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
		{
			var queryParams = new List<KeyValuePair<string, string>>();

			queryParams.Add(new KeyValuePair<string, string>("[filter]status", ((int)status).ToString()));

			if (count > 0)
				queryParams.Add(new KeyValuePair<string, string>("[paging]count", count.ToString()));

			if (startPostion > 0)
				queryParams.Add(new KeyValuePair<string, string>("[paging]startPostion", startPostion.ToString()));

			var httpResponseMessage = CallWebApi("GET", "/api/reminders" + BuildQueryString(queryParams));

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
			{
				throw GetException(httpResponseMessage);
			}

			var list = JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(
				httpResponseMessage.Content.ReadAsStringAsync().Result);

			if (list == null)
				throw new Exception($"Body cannot be parsed as List<ReminderItemGetModel>.");

			return list
				.Select(m => m.ToReminderItem())
				.ToList();
		}

		public bool Remove(Guid id)
		{
			var httpResponseMessage = CallWebApi("DELETE", $"/api/reminders/{id}");

			if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return false;
			}

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				throw GetException(httpResponseMessage);
			}

			return true;
		}

		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
			var contentModel = new ReminderItemsUpdateModel
			{
				Ids = ids.ToList(),
				PatchDocument = new JsonPatchDocument<ReminderItemUpdateModel>(
					new List<Operation<ReminderItemUpdateModel>>
					{
					new Operation<ReminderItemUpdateModel>
					{
						op = "replace",
						path = "/status",
						value = (int)status
					}
					},
					new DefaultContractResolver())
			};

			var result = CallWebApi(
				"PATCH",
				$"/api/reminders",
				JsonConvert.SerializeObject(contentModel));

			if (result.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				throw GetException(result);
			}
		}

		public void UpdateStatus(Guid id, ReminderItemStatus status)
		{
			var patchDocument = new JsonPatchDocument<ReminderItemUpdateModel>(
				new List<Operation<ReminderItemUpdateModel>>
				{
					new Operation<ReminderItemUpdateModel>
					{
						op = "replace",
						path = "/status",
						value = (int)status
					}
				},
				new DefaultContractResolver());

			var result = CallWebApi(
				"PATCH",
				$"/api/reminders/{id}",
				JsonConvert.SerializeObject(patchDocument));

			if (result.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				throw GetException(result);
			}
		}

		private HttpResponseMessage CallWebApi(
			string method,
			string relativeUrl,
			string content = null)
		{
			var request = new HttpRequestMessage(
				new HttpMethod(method),
				_baseWebApiUrl + relativeUrl);

			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			if (method == "POST" || method == "PATCH" || method == "PUT")
			{
				request.Content = new StringContent(
					content,
					Encoding.UTF8,
					"application/json");
			}

			return _httpClient.SendAsync(request).Result;
		}

		private string BuildQueryString(List<KeyValuePair<string, string>> queryParams)
		{
			if (queryParams?.Count == 0)
				return string.Empty;

			return "?" + string.Join(
				"&",
				queryParams
					.Select(kvp => kvp.Key + "=" + kvp.Value)
					.ToArray());
		}

		private Exception GetException(HttpResponseMessage result)
		{
			return new Exception(
				$"Error: {result.StatusCode}, " +
				$"Content: {result.Content.ReadAsStringAsync().Result}");
		}
	}
}
