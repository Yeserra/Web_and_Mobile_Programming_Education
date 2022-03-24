using BasicRepositorySoftDelete.Models.Classes;
using BasicRepositorySoftDelete.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Repos
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
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
                ent.Deleted = false;
                Set().Add(ent);
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
                //ent deleted kolonu true olmalı.
                ent.Deleted = true;
                Set().Update(ent);
                //_db.Entry(ent).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(int id)
        {
            return Set().Where(x => x.Deleted == false && x.Id == id).FirstOrDefault();
        }

        public List<T> List()
        {
            return Set().Where(x => x.Deleted == false).ToList();
        }

        public void Recover(int id)
        {
            T ent = Set().Where(x => x.Deleted == true && x.Id == id).FirstOrDefault();
            ent.Deleted = false;
        }

        public List<T> RecoverList()
        {
            return Set().Where(x => x.Deleted == true).ToList();
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<City> GetCityList()
        {
            return _db.Set<City>().Select(x => new City
            {
                Id = x.Id,
                CityName = x.CityName
            }).ToList();
        }
    }
}
