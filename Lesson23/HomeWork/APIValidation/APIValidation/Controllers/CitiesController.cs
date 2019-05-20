using Microsoft.AspNetCore.Mvc;
using APIValidation.DataLayer;
using APIValidation.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace APIValidation.Controllers
{
	[Route("/api/cities")]
	public class CitiesController : Controller
	{
		ILogger<CitiesController> _logger;
		ICitiesDataStore _citiesDataStore;

		public CitiesController(ILogger<CitiesController> logger, ICitiesDataStore citiesDataStore)
		{
			_logger=logger;
			_citiesDataStore = citiesDataStore;
		}


		[HttpGet()]
		public IActionResult GetCities()
		{
			var cities = _citiesDataStore.Cities;
			return Ok(cities);
		}

		[HttpGet("{id}", Name = "GetCity")]
		public IActionResult GetCity(int id)
		{
			_logger.LogInformation(($"{nameof(GetCities)} called"));

			var city = _citiesDataStore.Cities
				.Where(x => x.Id == id)
				.FirstOrDefault();

			if (city == null)
			{
				return NotFound();
			}

			return Ok(city);
		}

		[HttpPost()]
		public IActionResult AddCity([FromBody] CityUpdateModel city)
		{
			if(city==null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var citiesDataStore = _citiesDataStore;
			int newCityId = citiesDataStore.Cities
				.Max(x => x.Id) + 1;

			var newCity = new CityGetModel
			{
				Id = newCityId,
				Name = city.Name,
				Description = city.Description,
				NumberOfPointsInterest = city.NumberOfPointsInterest
			};

			citiesDataStore.Cities.Add(newCity);

			return CreatedAtRoute(
				"GetCity",
				new { id=newCityId }
				,newCity);
		}

        [HttpPut("{id}", Name = "GetCity")]
        public IActionResult UpdateCity([FromBody] CityUpdateModel cityForUpdate, int id)
        {
            foreach (var city in _citiesDataStore.Cities)
            {
                if (id == city.Id)
                {

                        if (!IsPropertyEqualChecher.isPropertyEqualCheck(city.Name, cityForUpdate.Name))
                        {
                            city.Name = cityForUpdate.Name;
                        }
                        if (!IsPropertyEqualChecher.isPropertyEqualCheck(city.Description, cityForUpdate.Description))
                        {
                            city.Description = cityForUpdate.Description;
                        }
                        if (!IsPropertyEqualChecher.isPropertyEqualCheck(city.NumberOfPointsInterest, cityForUpdate.NumberOfPointsInterest))
                        {
                            city.NumberOfPointsInterest = cityForUpdate.NumberOfPointsInterest;
                        }
                }
            }

            return Ok(cityForUpdate);
        }

        [HttpDelete("{id}", Name = "DeleteCity")]
        public IActionResult DeleteCity(int id)
        {
            if (_citiesDataStore.Cities.Exists(x => x.Id == id))
            {
                _citiesDataStore.Cities.Remove(_citiesDataStore.Cities.Find(x => x.Id == id));
            }
            else
            {
                return NotFound($"Object city with id = {id} not found");
            }
            return Ok();
        }
    }
}