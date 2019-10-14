using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountCore.BussinessLayer;
using AccountCore.BussinessLayer.Employee;
using AccountCore.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountCore.MVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services
                .AddApplicationDbContext(Configuration)
                .AddCustomAutoMapper()
                .AddBussinessLayer(Configuration)
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddBussinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<BussinessLayer.Mappings.MappingProfile>();
            }, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var isLocalDatabaseConnectionString = configuration["isLocalDatabaseConnection"];
            string databaseConnection;
            if (isLocalDatabaseConnectionString != null && bool.TryParse(isLocalDatabaseConnectionString, out var isLocalDatabaseConnection) && isLocalDatabaseConnection)
            {
                databaseConnection = configuration.GetConnectionString("DatabaseConnection");
            }
            else
            {
                databaseConnection = configuration["SQLConnectionString"];
            }

            services.AddDbContext<ApplicationDbContext>((optionsBuilder) =>
            {
                optionsBuilder
                    .UseSqlServer(databaseConnection ?? "Server=DESKTOP-8RUTKO2;Database=AccountCore;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            return services;
        }
    }
}
