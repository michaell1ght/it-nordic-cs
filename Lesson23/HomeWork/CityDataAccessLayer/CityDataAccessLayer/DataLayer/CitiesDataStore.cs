using System.Collections.Generic;

namespace APIValidation.DataLayer
{
	public class CitiesDataStore : ICitiesDataStore
	{
		public List<CityModel> Cities {get ; private set;}

		public CitiesDataStore()
		{
			Cities = new List<CityModel>()
			{
				new CityModel
				{
					Id = 1,
					Name = "Moscow",
					Description = "The capital of Russia"
				},
				new CityModel
				{
					Id = 2,
					Name = "New York",
					Description = "The one of the biggest cities in the world"
				}
			};
		}
	}
}