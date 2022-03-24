using BasicRepository.Models.Classes;
using BasicRepository.Models.Data;
using BasicRepository.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Repos
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        EmpContext _db;

        public BaseRepository(EmpContext db)
        {
            _db = db;
        }

        public bool Create(T ent)
        {
            try
            {
                _db.Set<T>().Add(ent);
                //_db.Entry(ent).State = EntityState.Added;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Delete(T ent)
        {
            try
            {
                Set().Remove(ent);
                //_db.Entry(ent).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public T Find(int id)
        {
            return Set().Find(id);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T ent)
        {
            try
            {
                Set().Update(ent);
                //_db.Entry(ent).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<City> GetCityList()
        {
            return _db.Set<City>().Select(x => new City
            {
                CityId = x.CityId,
                CityName = x.CityName
            }).ToList();
        }
    }
}
