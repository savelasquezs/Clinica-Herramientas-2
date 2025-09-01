using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model.Validations
{
    internal class MyStringValidator
    {
        public static  void ValidateStringNotEmpty(string value, string fieldName)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} no puede estar vacío.");
            }
        }
        public static void ValidateStringLength(string value, string fielName,  int? max=null, int? min=null)
        {
            ValidateStringNotEmpty(value, fielName);
            if (max.HasValue && value.Length > max.Value)
            {
                throw new ArgumentException($"{fielName} no puede tener más de {max.Value} caracteres.");
            }
            if (min.HasValue && value.Length < min.Value)
            {
                throw new ArgumentException($"{fielName} no puede tener menos de {min.Value} caracteres.");
            }
                
        }

        public static void ValidateStringIsNumeric(string value, string fieldName)
        {
            ValidateStringNotEmpty(value, fieldName);
            if (!value.All(char.IsDigit))
            {
                throw new ArgumentException($"{fieldName} debe contener solo números.");
            }
        }

        public static void ValidateEmailConstruction(string value, string fieldName)
        {
           ValidateStringNotEmpty(value, fieldName);

           if (!value.Contains('@') || !value.Contains('.') ||value.StartsWith('.') || value.EndsWith('.') ||value.StartsWith('@') || value.EndsWith('@'))
            {
                throw new ArgumentException($"{fieldName} debe ser un email válido.");
           }
        }

        public static void ValidateStringIsAlphaNumeric(string value, string fieldName)
        {
           ValidateStringNotEmpty(value, fieldName);
              if (!value.All(c => char.IsLetterOrDigit(c)))
              {
                throw new ArgumentException($"{fieldName} debe contener solo letras, números.");
            }
        }

    }
}
