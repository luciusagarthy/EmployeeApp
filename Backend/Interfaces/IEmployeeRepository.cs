using Backend.DataObjects;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeBO>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        Task<Employee?> CreateAsync(EmployeeCO employeeModel);

        Task<Employee?> UpdateAsync(int id, EmployeeCO employeeModel);

        Task<Employee?> DeleteAsync(int id);
    }
}
