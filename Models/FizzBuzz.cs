using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorFizzBuzz.Models
{
    public class FizzBuzz : IValidatableObject
    {
        [Required(ErrorMessage = "Fizz value is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Fizz value must be a positive integer.")]
        public int? FizzValue { get; set; }

        [Required(ErrorMessage = "Buzz value is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Buzz value must be a positive integer.")]
        public int? BuzzValue { get; set; }

        [Required(ErrorMessage = "Stop value is required.")]
        [Range(1, 10000, ErrorMessage = "Stop value must be between 1 and 10000.")]
        public int? StopValue { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FizzValue is not int fizz || BuzzValue is not int buzz || StopValue is not int stop)
            {
                yield break;
            }

            if (buzz <= fizz)
            {
                yield return new ValidationResult(
                    "Buzz value must be greater than the fizz value.",
                    new[] { nameof(BuzzValue) });
            }

            var product = (long)fizz * buzz;
            if (stop <= product)
            {
                yield return new ValidationResult(
                    "Stop value must be greater than the product of fizz and buzz.",
                    new[] { nameof(StopValue) });
            }
        }
    }
}
