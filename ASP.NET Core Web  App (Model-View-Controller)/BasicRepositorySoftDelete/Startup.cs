.
.
.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EmpContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("Baglanti")));
            services.AddScoped<CityRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<CityModel>();
            services.AddScoped<EmployeeModel>();
        }
.
.
.
