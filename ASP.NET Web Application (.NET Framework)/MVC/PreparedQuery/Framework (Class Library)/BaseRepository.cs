using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        SqlConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

        string tableName = typeof(T).Name;
        string key = typeof(T).Name + "Id";

        public void Create(T entity, bool removeId)
        {
            var props = GetProperties();
            if (removeId)
            {
                props.RemoveAt(0);
            }
            string cols = GetInsertColumns(props);
            string val = GetValue(props);
            string qry = $"insert into {tableName} {cols} {val}";
            _db.Execute(qry, entity);
        }

        private string GetInsertColumns(List<PropertyInfo> props)
        {
            //insert into Degree-->(DegreeName, DegreeId)<-- Values(@DegreeName)
            string col = "(";
            foreach (var item in props)
            {
                col += item.Name + ",";
            }
            col = col.Remove(col.Length - 1, 1);
            col += ")";
            return col;
        }

        private string GetValue(List<PropertyInfo> props)
        {
            //insert into Degree(DegreeName) Values-->(@DegreeName)<--
            string val = "Values(";
            foreach (var item in props)
            {
                val += "@" + item.Name + ",";
            }
            val = val.Remove(val.Length - 1, 1);
            val += ")";
            return val;
        }

        public void Delete(dynamic id)
        {
            _db.ExecuteScalar<int>($"delete from {tableName} where {key} = '{id}'");
        }

        public T Find(dynamic id)
        {
            //string key = typeof(T).Name + "id";
            return _db.Query<T>($"select * from {tableName} where {key} = '{id}'").First();
        }

        public T Find(string id)
        {
            //string key = typeof(T).Name + "id";
            return _db.Query<T>($"select * from {tableName} where {key} = '{id}'").First();
        }

        public List<PropertyInfo> GetProperties()
        {
            var props = typeof(T).GetProperties().ToList();
            return props;
        }

        public List<T> List()
        {
            return _db.Query<T>($"select * from {tableName}").ToList();
        }

        public List<T> List(string tablename)
        {
            return _db.Query<T>($"select * from {tablename}").ToList();
        }

        public void Update(T entity, dynamic id)
        {
            var props = GetProperties();
            string key = props[0].Name;
            props.RemoveAt(0);
            string val = GetUpdateColumns(props);
            string qry = $"update {tableName} {val} where {key} = '{id}'";
            _db.Execute(qry, entity);
        }

        private string GetUpdateColumns(List<PropertyInfo> props)
        {
            //update Degree set DegreeName = @DegreeName where DegreeId = 1
            string val = "set ";
            foreach (var item in props)
            {
                val += item.Name + " " + "= " + "@" + item.Name + ",";
            }
            val = val.Remove(val.Length - 1, 1);
            return val;
        }
    }
}
