using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PointOfSale.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsValidFromClass : ValidationAttribute
    {
        private readonly Type _classType;
        public IsValidFromClass(Type type)
        {
            _classType = type;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            if (value is string stringValue)
            {
                HashSet<string> validProperties = _classType
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(p => p.Name)
                    .ToHashSet();

                if (!validProperties.Contains(stringValue))
                {
                    return new ValidationResult($"El valor '{stringValue}' no es una propiedad válida de {_classType.Name}. Propiedades permitidas: {string.Join(", ", validProperties)}.");
                }
            }

            return ValidationResult.Success!;
        }



    }
}
