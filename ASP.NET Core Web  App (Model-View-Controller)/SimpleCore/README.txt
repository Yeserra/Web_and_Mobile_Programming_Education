appsettings.json:

{
  "ConnectionStrings": {
    "Connection": "Server=(local);Database=DBsimpleCore;Trusted_Connection=True;"
  },

  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
___________________________________________________________________________________________________________________________

startup.cs:
.
.
.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EmpContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddScoped<CityModel>();
            services.AddScoped<EmployeeModel>();
        }
.
.
.
____________________________________________________________________________________________________________________________

Ve Migration yapılır:

Add-Migration temp
Update-Databse
