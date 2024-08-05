using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
