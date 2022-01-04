using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleREST_API.Repositories.Concrete;
using SampleREST_API.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleREST_API.Services.Abstract;
using SampleREST_API.Services.Concrete;
using SampleREST_API.Models;
using Microsoft.EntityFrameworkCore;
using SampleREST_API.Models.Sorting;
using SampleREST_API.Models.Custom;
using AspNetCoreRateLimit;

namespace SampleREST_API
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
            services.AddOptions();

            services.AddMemoryCache();

            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            services.AddInMemoryRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddControllers();

            services.AddDbContext<RESTAPIDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("MSSQLDBContext")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDogService, DogService>();

            services.AddScoped<ISortHelper<Dog>, SortHelper<Dog>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIpRateLimiting();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
