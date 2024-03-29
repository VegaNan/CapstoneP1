using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using VegaN_Capstone.Data;
using VegaN_Capstone.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VegaN_Capstone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            services.AddControllersWithViews();

            //configuring our mongo settings (connection and database) 
            services.Configure<Mongosettings>(options =>
            {
                options.Connection = Configuration.GetSection("MongoSettings:Connection").Value;
                options.DatabaseName = Configuration.GetSection("MongoSettings:Database").Value;
                options.UsersCollectionName = Configuration.GetSection("MongoSettings:UsersCollection").Value;
               
            });

            services.AddTransient<MongoDBDal>();
            services.AddTransient<IMongoDBContext, MongoDBContext>();


            services.Configure<SqlServerSettings>(options =>
            {
                options.Database = Configuration.GetSection("SqlSettings:Database").Value;
                options.UserId = Configuration.GetSection("SqlSettings:UserId").Value;
                options.Password = Configuration.GetSection("SqlSettings:Password").Value;
                options.Server = Configuration.GetSection("SqlSettings:Server").Value;

            });


            services.AddTransient<SqlServerDBContext>();
            services.AddTransient<SqlServerDBDal>();

            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
