﻿using APIValidation.Validation;
using System.ComponentModel.DataAnnotations;

namespace APIValidation.Models
{
	public class CityGetModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int NumberOfPointsInterest { get; set; }
	}
}