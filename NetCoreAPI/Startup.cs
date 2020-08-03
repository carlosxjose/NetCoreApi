using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NetCoreAPI.Middlewares;
using System;
using System.Net.NetworkInformation;

namespace NetCoreAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public static string ConnectionString { get; private set; }
        public static string ConnectionStringAut { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            Action<Entities.DTOs.Configurations> Config = (cf =>
            {
                cf.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                cf.ConnectionStringAut = Configuration.GetConnectionString("DefaultConnectionA");
            });
            services.Configure(Config);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<Entities.DTOs.Configurations>>().Value);
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

            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            ConnectionStringAut = Configuration.GetConnectionString("DefaultConnectionAut");

            //app.UseMiddleware<BasicAuthMiddleware>("example.com");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
