using System;
using BeyondTokenTrackerApp.Mapping;
using DAL.Context;
using DAL.Repositories;
using Domain.Repositories.Interfaces;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BeyondTokenTrackerApp
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
            services.AddDbContext<BeyondTokenTrackerContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            // Setup AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceMappingProfile());
            });
            services.AddSingleton(config.CreateMapper());

            // Add cors
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = int.Parse(Configuration["HttpsRedirectionPort"]);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Add framework services.
            services.AddMvc().AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddControllersAsServices();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();

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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            //Configure Cors
            app.UseCors("default");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(120);
                   // spa.UseProxyToSpaDevelopmentServer("https://localhost:44301/");
                }
            });
        }
    }
}
