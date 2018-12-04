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
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddTransient<IBookService, BookService>(); // при каждом обращении к IRepository SqlRepository создается каждый раз
            services.AddScoped<IBookService, BookService>(); // в рамках одного запроса один раз создается SqlRepository
            //services.AddSingleton<IBookService, BookService>();

            services.AddDbContext<BooksContext>(options =>
            {
                string connstr = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connstr);
                options.UseLazyLoadingProxies();
            });
            //services.AddTransient<BookService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // отображает в браузере ошибку, чтоб откл переходим c developer на release
            }

            app.UseMvc(routeBuilder => {
                //routeBuilder.MapRoute(
                //    name: "math",
                //    template: "math/{action}/{num1:int}/{num2:int}",
                //    defaults: new { controller = "Math" }
                //    );

                routeBuilder.MapRoute(
                    name: "math",
                    template: "math/{action}/{num1:int}/{*catchall}",
                    defaults: new { controller = "Math" }
                    );

                routeBuilder.MapRoute(
                    name: "books",
                    template: "books",
                    defaults: new { controller = "Book", action = "All" }
                    );

                routeBuilder.MapRoute(
                    name: "getbook",
                    template: "books/{id:int}",
                    defaults: new { controller = "Book", action = "Get" }
                    );

                routeBuilder.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}" // ? не обязательный параметр
                    );
            });

            app.Run(async (context) => {
                await context.Response.WriteAsync("NOT FOUND");
            });
        }
    }
}
