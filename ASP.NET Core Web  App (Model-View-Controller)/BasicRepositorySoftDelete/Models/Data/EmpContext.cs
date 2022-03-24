using BasicRepositorySoftDelete.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Models.Data
{
    public class EmpContext: DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> op): base(op)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
    }
}
