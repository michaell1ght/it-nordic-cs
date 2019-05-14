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

        [HttpPut()]
        public IActionResult ReplaceCity([FromBody] CityGetModel cityForUpdate)
        {
            //Добавить проверку на то, что все передаваемые поля не null. Вынести эту логику в модель.
            if (cityForUpdate == null)
            {
                return BadRequest();
            }
            var citiesDataStore = CitiesDataStore.GetCityDataStoreInstance();
            foreach (var city in citiesDataStore.Cities)
            {
                if (cityForUpdate.Id == city.Id)
                {
                    if (cityForUpdate == city)
                    {
                        return BadRequest();
                    }

                    //Добавить логику, чтобы поля были не null, если значение не передано. Подумать, как этто сделать линками.
                    else
                    {
                        city.Id = cityForUpdate.Id;
                        city.Name = cityForUpdate.Name;
                        city.Description = cityForUpdate.Description;
                        city.NumberOfPointsInterest = cityForUpdate.NumberOfPointsInterest;
                    }
                }
            }

            return Ok(cityForUpdate);
        }

        [HttpDelete("{id}", Name = "DeleteCity")]
        public IActionResult DeleteCity(int id)
        {
            //Подумать, как получше переписать удаление (Костыль с Find внутри Remove)
            var citiesDataStore = CitiesDataStore.GetCityDataStoreInstance();
            if (citiesDataStore.Cities.Exists(x => x.Id == id))
            {
                citiesDataStore.Cities.Remove(citiesDataStore.Cities.Find(x => x.Id == id));
            }
            else
            {
                return NotFound($"City with id = {id} not found");
            }
            return Ok();
        }
    }
}