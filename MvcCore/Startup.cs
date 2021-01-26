using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcCore.Data;
using MvcCore.Helpers;
using MvcCore.Repositories;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MvcCore
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            String cadenasql = this.Configuration.GetConnectionString("casasqlhospital");
            String cadenaoracle = this.Configuration.GetConnectionString("casaoraclehospital");
            String cadenamysql = this.Configuration.GetConnectionString("casamysqlhospital");
            String cadenasqlazure = this.Configuration.GetConnectionString("azuresql");
            services.AddTransient<PathProvider>();
            services.AddTransient<RepositoryJoyerias>();
            services.AddTransient<RepositoryAlumnos>();
            //services.AddTransient<RepositoryDepartamentosXML>();
            //services.AddTransient<IRepositoryDepartamentos, RepositoryDepartamentosXML>();
            //services.AddTransient<IRepositoryDepartamentos, RepositoryDepartamentosSQL>();
            //services.AddTransient<IRepositoryDepartamentos, RepositoryDepartamentosMySql>();
            //services.AddTransient<IRepositoryDepartamentos>(x =>
            //    new RepositoryDepartamentosOracle(cadenaoracle));
            services.AddTransient<IRepositoryHospital, RepositoryHospital>();
            services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadenasql));
            //services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadenasqlazure));
            //services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadenaoracle));
            //services.AddDbContext<HospitalContext>(options => options.UseMySql(cadenamysql, new MySqlServerVersion(new Version(8, 0, 22)), mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)));
            //services.AddDbContextPool<HospitalContext>(options => options.UseMySql(cadenamysql, ServerVersion.AutoDetect(cadenamysql)));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
