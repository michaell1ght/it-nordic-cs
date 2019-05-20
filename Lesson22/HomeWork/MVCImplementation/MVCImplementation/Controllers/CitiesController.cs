using Microsoft.AspNetCore.Mvc;
using MVCImplementation.DataLayer;
using MVCImplementation.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCImplementation.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            var citiesDataStore = CitiesDataStore.GetCityDataStoreInstance();
            var cities = citiesDataStore.Cities;
            return Ok(cities);
        }

        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetCityDataStoreInstance();
            var city = citiesDataStore.Cities
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpPost()]
        public IActionResult AddCity([FromBody] CityGetModel city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            var citiesDataStore = CitiesDataStore.GetCityDataStoreInstance();
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
                new { id = newCityId }
                , newCity);
        }

        [HttpPut("{id}", Name = "GetCity")]
        public IActionResult UpdateCity([FromBody] CityUpdateModel cityForUpdate, int id)
        {
            var citiesDataStore = CitiesDataStore.GetCityDataStoreInstance();
            foreach (var city in citiesDataStore.Cities)
            {
                if (id == city.Id)
                {

                    if (city.Name == null)
                    {
                        return BadRequest($"Property {nameof(city.Name) } can not have a null value");
                    }

                    else
                    {
                        if (!IsPropertyEqualChecher.isPropertyEqualCheck(city.Name, cityForUpdate.Name))
                        {
                            city.Name = cityForUpdate.Name;
                        }
                        if(!IsPropertyEqualChecher.isPropertyEqualCheck(city.Description, cityForUpdate.Description))
                        {
                            city.Description = cityForUpdate.Description;
                        }
                        if (!IsPropertyEqualChecher.isPropertyEqualCheck(city.NumberOfPointsInterest, cityForUpdate.NumberOfPointsInterest))
                        {
                            city.NumberOfPointsInterest = cityForUpdate.NumberOfPointsInterest;
                        }
                    }
                }
            }

            return Ok(cityForUpdate);
        }

        [HttpDelete("{id}", Name = "DeleteCity")]
        public IActionResult DeleteCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetCityDataStoreInstance();
            if (citiesDataStore.Cities.Exists(x => x.Id == id))
            {
                citiesDataStore.Cities.Remove(citiesDataStore.Cities.Find(x => x.Id == id));
            }
            else
            {
                return NotFound($"Object city with id = {id} not found");
            }
            return Ok();
        }
    }
}