using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Database
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
        : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
