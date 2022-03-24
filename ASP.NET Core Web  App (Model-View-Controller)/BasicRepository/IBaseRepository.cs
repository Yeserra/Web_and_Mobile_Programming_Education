using BasicRepository.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Repos
{
    public interface IBaseRepository<T> where T: class
    {
        bool Update(T ent);
        bool Create(T ent);
        bool Delete(T ent);
        T Find(int id);
        List<T> List();
        void Save();
        DbSet<T> Set();
        List<City> GetCityList();
    }
}
