using Backend.Data;
using System.ComponentModel.DataAnnotations;

namespace Backend.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            var email = value != null ? (String)value : "";

            var _context = (EmployeeDbContext)context.GetService(typeof(EmployeeDbContext));

            if (_context.Employee.Any(e => e.Email == email))
            {
                return new ValidationResult("Emailová adresa již v databázi existuje. Zadejte jinou emailovou adresu");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
