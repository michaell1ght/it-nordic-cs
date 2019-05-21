using APIValidation.Validation;
using System.ComponentModel.DataAnnotations;

namespace APIValidation.Models
{
	public class CityGetModel
	{
        [Required]
		public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The name of a city shouldn't be longer than 100 characters")]
        [MinLength(1, ErrorMessage = "The name of a city shouldn't be empty")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description shouldn't be longer than 255 characters")]
        [MinLength(1, ErrorMessage = "The name of a city shouldn't be empty")]
        public string Description { get; set; }

        [Range(0, 100)]
        public int NumberOfPointsInterest { get; set; }
    }
}