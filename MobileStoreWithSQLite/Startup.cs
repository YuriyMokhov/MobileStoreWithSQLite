using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MobileStoreWithSQLite.Data;
using MobileStoreWithSQLite.Services;
using MobileStoreWithSQLite.Utils;

namespace MobileStoreWithSQLite
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
            services.AddTransient<DbOptionsFactory, SQLiteOptionsFactory>();
            services.AddDbContext<MobileStoreContext>((sp, option) =>
            {
                var optionsFactoty = sp.GetService<DbOptionsFactory>();
                optionsFactoty.Configuration(option, Configuration);
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddControllersWithViews();
            services.AddTransient<HtmlMusicResult>();
            services.AddTransient<ICustomService, CustomService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "service",
                    pattern: "Service/{action}/{code?}", new { controller = "Service", action = "GetStatusCode"});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
