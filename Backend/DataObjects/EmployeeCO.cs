using Backend.Validators;
using System.ComponentModel.DataAnnotations;

namespace Backend.DataObjects
{
    public class EmployeeCO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; } = decimal.Zero;
    }
}
