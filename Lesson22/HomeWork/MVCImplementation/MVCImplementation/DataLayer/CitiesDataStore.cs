using MVCImplementation.Models;
using System.Collections.Generic;

namespace MVCImplementation.DataLayer
{
	public class CitiesDataStore
	{
		private static CitiesDataStore _store;
		public List<CityGetModel> Cities {get ; private set;}

		private CitiesDataStore()
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
		public static CitiesDataStore GetCityDataStoreInstance()
		{
			if(_store == null)
			{
				_store = new CitiesDataStore();
			}
			return _store;
		}
    }
}