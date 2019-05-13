using APIValidation.Models;
using System.Collections.Generic;

namespace APIValidation.DataLayer
{
	public class CitiesDataStore : ICitiesDataStore
	{
		public List<CityGetModel> Cities {get ; private set;}

		public CitiesDataStore()
		{
			//добавить отдельную модель и сматчить её и модель города через контроллер
			Cities = new List<CityGetModel>()
			{
				new CityGetModel
				{
					Id = 1,
					Name = "Moscow",
					Description = "The capital of Russia"
				},
				new CityGetModel
				{
					Id = 2,
					Name = "New York",
					Description = "The one of the biggest cities in the world"
				}
			};
		}
	}
}