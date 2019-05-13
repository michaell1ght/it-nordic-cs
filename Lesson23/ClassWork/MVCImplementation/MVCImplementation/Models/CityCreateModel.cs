using APIValidation.Validation;
using System.ComponentModel.DataAnnotations;

namespace APIValidation.Models
{
	public class CityCreateModel
	{
		[Required]
		[MaxLength(100, ErrorMessage = "The name of a city shouldn't be longer than 100 characters")]
		public string Name  { get; set; }

		[MaxLength(255, ErrorMessage = "Description shouldn't be longer than 255 characters")]
		[DifferentValue(OtherProperty = "Name")]
		public string Description { get; set; }

		[Range(0,100)]
		public int NumberOfPointsInterest { get; set; }
	}
}