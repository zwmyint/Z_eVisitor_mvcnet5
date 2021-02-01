using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVisitor_mvcnet5.Common;
using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;
using eVisitor_mvcnet5.Service.ServicesRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eVisitor_mvcnet5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            // added
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBDefaultConnection")));
            services.AddDbContext<AppDbContext2>(options => options.UseSqlServer(Configuration.GetConnectionString("DBDefaultConnection2")));

            // for Dapper
            services.AddSingleton<IConfiguration>(Configuration);
            Global.ConnectionString = Configuration.GetConnectionString("DBDefaultConnection2");

            // for Dapper
            services.AddScoped<IStudentService, StudentServiceRepo>();
            services.AddScoped<ISchoolService, SchoolServiceRepo>();

            services.AddScoped<IDapper, Dapperr>(); 

            // EF and Dapper test
            //services.AddScoped<ICompanyService, CompanyServiceRepoEF>(); //EF
            services.AddScoped<ICompanyService, CompanyServiceRepo>(); //Dapper

            services.AddControllersWithViews();

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
