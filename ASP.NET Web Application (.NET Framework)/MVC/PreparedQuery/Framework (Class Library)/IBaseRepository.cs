using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public interface IBaseRepository<T> where T: class
    {
        void Delete(dynamic id);
        void Update(T entity, dynamic id);
        void Create(T entity, bool removeId);
        T Find(dynamic id);
        List<T> List();
        List<PropertyInfo> GetProperties();
    }
}
