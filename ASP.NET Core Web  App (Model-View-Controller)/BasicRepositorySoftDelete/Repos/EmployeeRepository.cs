using BasicRepositorySoftDelete.Models.Classes;
using BasicRepositorySoftDelete.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Repos
{
    public class EmployeeRepository: BaseRepository<Employee>
    {
        public EmployeeRepository(EmpContext db) : base(db)
        {

        }
    }
}
