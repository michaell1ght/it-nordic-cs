using APIValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIValidation.DataLayer
{
	public interface ICitiesDataStore
	{
		List<CityGetModel> Cities { get;}
	}
}
