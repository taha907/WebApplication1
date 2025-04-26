
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); //wwwroot klasörünü kullýnam açar


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            
            {
                //default routing 
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern : "{controller=Home}/{action=Index}/{id?}");

                
                ////localhost:17724/{controler}/{action}
                //endpoints.MapControllerRoute(
                //    name: "Home",
                //    pattern: "",
                //    defaults: new { controller = "Home", action = "Home" }
                //    );

                ////localhost:17724/about
                //endpoints.MapControllerRoute(
                //    name :"About",
                //    pattern : "about",
                //    defaults:new {controller = "Home", action = "About"});

                ////localhost:17724/movies/list
                //endpoints.MapControllerRoute(
                //    name : "movieList",
                //    pattern : "movies/list",
                //    defaults : new {controller ="Movies", action = "List" }

                //    );

                ////localhost:17724/movies/details
                //endpoints.MapControllerRoute(
                //    name: "details",
                //    pattern: "movies/details",
                //    defaults: new { controller = "Movies", action = "Details" }

                //    ); ctrl+k+c
            });
        }
    }
}
