using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Controllers
{
	[Route("api/reminders")]
	[ApiController]
	public class RemindersController : ControllerBase
	{
		private IReminderStorage _reminderStorage;

		public RemindersController(IReminderStorage reminderStorage)
		{
			_reminderStorage = reminderStorage;
		}

		[HttpHead]
		public IActionResult GetRemindersCount()
		{
			Response.Headers.Add("X-Total-Count", _reminderStorage.Count.ToString());
			return Ok();
		}

		[HttpPost]
		public IActionResult CreateReminder([FromBody] ReminderItemCreateModel reminder)
		{
			if (reminder == null || !ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var reminderItem = reminder.ToReminderItem();
			Guid id = _reminderStorage.Add(reminderItem);

			return CreatedAtRoute(
				"GetReminder",
				new { id },
				new ReminderItemGetModel(id, reminderItem));
		}

		[HttpGet("{id}", Name = "GetReminder")]
		public IActionResult GetReminder(Guid id)
		{
			var reminderItem = _reminderStorage.Get(id);

			if (reminderItem == null)
			{
				return NotFound();
			}

			return Ok(new ReminderItemGetModel(reminderItem));
		}

		[HttpGet]
		public IActionResult GetReminders(
			[FromQuery(Name = "[filter]status")] int status = -1,
			[FromQuery(Name = "[paging]count")] int count = 0,
			[FromQuery(Name = "[paging]startPosition")] int startPosiotion = 0)
		{
			IEnumerable<ReminderItemGetModel> reminderItemGetModels;

			if (status < 0)
			{
				reminderItemGetModels = _reminderStorage
					.Get(count, startPosiotion)
					.Select(ri => new ReminderItemGetModel(ri));
			}
			else
			{
				reminderItemGetModels = _reminderStorage
					.Get((ReminderItemStatus)status, count, startPosiotion)
					.Select(ri => new ReminderItemGetModel(ri));
			}

			return Ok(reminderItemGetModels);
		}

		[HttpDelete("{id}")]
		public IActionResult RemoveReminder(Guid id)
		{
			var reminderItem =
				_reminderStorage
					.Get(id);

			if (reminderItem == null)
			{
				return BadRequest();
			}

			_reminderStorage.Remove(id);

			return NoContent();
		}

		[HttpPatch("{id}")]
		public IActionResult UpdateReminderStatus(
			Guid id,
			[FromBody] JsonPatchDocument<ReminderItemUpdateModel> patchDocument)
		{
			var reminderItem = _reminderStorage.Get(id);

			if(reminderItem == null)
			{
				return BadRequest();
			}

			if(patchDocument == null || !ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var reminderItemUpdateModelToPatch = new ReminderItemUpdateModel(reminderItem);
			patchDocument.ApplyTo(reminderItemUpdateModelToPatch);

			_reminderStorage.UpdateStatus(id, reminderItemUpdateModelToPatch.Status);

			return NoContent();
		}

		[HttpPatch]
		public IActionResult UpdateRemindersStatus(
			[FromBody] ReminderItemsUpdateModel reminderItemsUpdateModel)
		{
			if (reminderItemsUpdateModel == null || !ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var reminderItemUpdateModelToPatch = new ReminderItemUpdateModel();
			reminderItemsUpdateModel.PatchDocument.ApplyTo(
				reminderItemUpdateModelToPatch);

			_reminderStorage.UpdateStatus(
				reminderItemsUpdateModel.Ids,
				reminderItemUpdateModelToPatch.Status);

			return NoContent();
		}
	}
}
