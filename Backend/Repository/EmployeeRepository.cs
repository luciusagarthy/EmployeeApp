using Backend.Data;
using Backend.DataObjects;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> CreateAsync(EmployeeCO employee)
        {
            var employeeModel = employee.EmployeeFromApi();

            await _context.Employee.AddAsync(employeeModel);

            await _context.SaveChangesAsync();

            return employeeModel;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var employeeModel = await _context.Employee.FirstOrDefaultAsync(a => a.Id == id);

            if (employeeModel == null)
            {
                return null;
            }

            _context.Employee.Remove(employeeModel);

            await _context.SaveChangesAsync();

            return employeeModel;
        }

        public async Task<List<EmployeeBO>> GetAllAsync()
        {
            var employees = await _context.Employee.ToListAsync();
            var employeesBO = employees.Select(a => a.EmployeeToBO()).ToList();

            return employeesBO;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Employee?> UpdateAsync(int id, EmployeeCO employee)
        {
            var employeeModel = await _context.Employee.FirstOrDefaultAsync(a => a.Id == id);

            if (employeeModel == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(employee.Name))
            {
                employeeModel.Name = employee.Name;
            }

            if (!string.IsNullOrEmpty(employee.Email))
            {
                employeeModel.Email = employee.Email;
            }

            if (!string.IsNullOrEmpty(employee.Position))
            {
                employeeModel.Position = employee.Position;
            }

            if (!string.IsNullOrEmpty(employee.Department))
            {
                employeeModel.Department = employee.Department;
            }

            if (employee.Salary > 0)
            {
                employeeModel.Salary = employee.Salary;
            }

            await _context.SaveChangesAsync();

            return employeeModel;
        }
    }
}
