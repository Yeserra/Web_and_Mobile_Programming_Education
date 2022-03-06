1. Properties -> Settings -> Type: (ConnectionString), Value: ServerName + Var olmayan bir database adı yazılır.
2. ADO.NET Entity Data Model -> Empty Code First model seçilir.
3. Bir yapılandırma dosyası oluşur.
4. Buraya "DbSet<>" türünde oluşturulmak istenen tablolar yazılır (prop). Ve her tablo için class yazıp içinde prop'lar tanımlanır.
_______________________________________________________________________________________________________________________________________
      using System;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;
      using System.Data.Entity;
      using System.Linq;

      namespace CodeFirst_EF.Models.Data
      {
          public class SchoolContext : DbContext
          {
              // Your context has been configured to use a 'SchoolContext' connection string from your application's 
              // configuration file (App.config or Web.config). By default, this connection string targets the 
              // 'CodeFirst_EF.Models.Data.SchoolContext' database on your LocalDb instance. 
              // 
              // If you wish to target a different database and/or database provider, modify the 'SchoolContext' 
              // connection string in the application configuration file.
              public SchoolContext()
                  : base("Connection")
              {
              }

              // Add a DbSet for each entity type that you want to include in your model. For more information 
              // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

              // public virtual DbSet<MyEntity> MyEntities { get; set; }

              public virtual DbSet<Student> Student { get; set; }
              public virtual DbSet<Teacher> Teacher { get; set; }
              public virtual DbSet<City> City { get; set; }
          }

          //public class MyEntity
          //{
          //    public int Id { get; set; }
          //    public string Name { get; set; }
          //}

          abstract public class Base
          {
              [Key]
              public int Id { get; set; }
              public string Name { get; set; }
              public string Surname { get; set; }
              public int CityId { get; set; }
              public string MotherName { get; set; }

              [ForeignKey("CityId")] //CityId'nin üzerinde olması gerekmez ama mutlaka aşağıdaki bağlantının üzerinde olmalıdır!
              public virtual City City { get; set; }
              public string FullName()
              {
                  return Name + " " + Surname;
              }
          }

          public class Student : Base
          {

          }

          public class Teacher : Base
          {
              public int Salary { get; set; }
          }

          public class City
          {
              public City()
              {
                  this.Students = new HashSet<Student>();
                  this.Teachers = new HashSet<Teacher>();
              }

              [Key]
              public int CityId { get; set; }
              public string CityName { get; set; }
              public virtual ICollection<Student> Students { get; set; }
              public virtual ICollection<Teacher> Teachers { get; set; }
          }
      }
____________________________________________________________________________________________________________________________________________________

5. Tablolar hazır olduğunda Migration yapılır.

Enable-Migrations: Bir Configuraiton sınıfı oluşturarak projede geçişi etkinleştirir.
Add-Migration: Up() ve Down() methodlarıyla belirtilen her bir isme göre yeni bir geçiş sınıfı (migration class) oluşturur.
Update-Database: En son oluşturulan migration dosyasınıı yürütür ve değişiklikleri veritabanı şemasına uygular.
