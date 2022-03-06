using Microsoft.EntityFrameworkCore;
using SimpleCore.Models.Classes;

namespace SimpleCore.Models.Data
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {
            // Sayesinde newlemeye gerek yok (Core'un özelliği)
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
    }
}
