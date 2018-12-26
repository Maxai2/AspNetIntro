using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WepApi.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        private AuthOptions authOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            authOptions = Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>(); // for local
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthOptions>(Configuration); // for everywhere
            services.Configure<AuthOptions>(options =>
            {
                Configuration.GetSection(nameof(AuthOptions)).Bind(options);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),

                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IBookService, BookService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Header: Authentication (Bearer token1/3.token2/3.token3/3)
            // HttpContext.User = из Claims в Payload
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
