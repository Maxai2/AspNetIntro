using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;
using Caching.EF;
using Caching.Services;

namespace Caching
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LibConnection"));
            });

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<LibContext>();

            services.AddResponseCompression(); // Compression
            services.Configure<GzipCompressionProviderOptions>(
                options =>
                {
                    options.Level = CompressionLevel.Optimal;
                });

            services.AddMemoryCache(); // or Caching
            //services.AddSingleton<IMemoryCache, MemoryCache>(); // or Caching

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression(); // Compression

            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions() {
            //    OnPrepareResponse = sfcnt =>
            //    {
            //        sfcnt.Context.Response.Headers.Add(
            //            "Cache-Control", "private,max-age=60");
            //    }
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                    );
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
