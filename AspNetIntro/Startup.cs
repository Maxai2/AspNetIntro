using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetIntro.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetIntro
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IBookService, BookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute(); //"{controller=Home}/{action=Index}"
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller}/{action}");
            });

            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Cookies["token"] != null)
            //        await next.Invoke();
            //    else
            //        await context.Response.WriteAsync("No Token!");
            //});

            //app.Run(async (context) => // Always Last
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
