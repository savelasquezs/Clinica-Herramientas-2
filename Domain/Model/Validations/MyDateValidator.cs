using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model.Validations
{
    internal class MyDateValidator
    {
        public static void ValidateDateNotInFuture(DateTime date, string fieldName)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentException($"{fieldName} no puede ser una fecha futura.");
            }
        }
        public static void ValidateDateOfBith(DateTime date, string fieldName, int minAge = 0, int maxAge = 150)
        {
            var age = DateTime.Now.Year - date.Year;
            if (date > DateTime.Now.AddYears(-age)) age--;
            if (age < minAge || age > maxAge)
            {
                throw new ArgumentException($"{fieldName} debe estar entre {minAge} y {maxAge} años.");
            }
        }
    }
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        public DateNotInFutureAttribute() : base("{0} no puede ser una fecha futura.")
        {
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            // Handle null values - let [Required] attribute handle null validation
            if (value == null)
                return ValidationResult.Success;

            // Ensure we have a DateTime
            if (value is DateTime date)
            {
                try
                {
                    // Safe null-coalescing for field name
                    string fieldName = validationContext?.DisplayName
                                    ?? validationContext?.MemberName
                                    ?? "Campo";

                    MyDateValidator.ValidateDateNotInFuture(date, fieldName);
                    return ValidationResult.Success;
                }
                catch (ArgumentException ex)
                {
                    return new ValidationResult(ex.Message);
                }
            }

            // Handle invalid type
            string displayName = validationContext?.DisplayName
                              ?? validationContext?.MemberName
                              ?? "El campo";

            return new ValidationResult($"{displayName} debe ser una fecha válida.");
        }
    }
}
