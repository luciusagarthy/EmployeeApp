using Backend.DataObjects;
using Backend.Models;

namespace Backend.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeBO EmployeeToBO(this Employee employee)
        {
            return new EmployeeBO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Position = employee.Position,
                Department = employee.Department,
                Salary = employee.Salary
            };
        }

        public static Employee EmployeeFromApi(this EmployeeCO employee)
        {
            return new Employee
            {
                Name = employee.Name,
                Email = employee.Email,
                Position = employee.Position,
                Department = employee.Department,
                Salary = employee.Salary
            };
        }
    }
}
