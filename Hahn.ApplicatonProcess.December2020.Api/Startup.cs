using Hahn.ApplicatonProcess.December2020.Domain.Repository;
using Hahn.ApplicatonProcess.December2020.Domain.Repository.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Services;
using Hahn.ApplicatonProcess.December2020.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Hahn.ApplicatonProcess.December2020.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicatonProcess.December2020.Api", Version = "v1" });
            });
            ConfigureTransientServices(services);
            ConfigureRepositories(services);
            ConfigureEntityFramework(services);
        }

        private static void ConfigureTransientServices(IServiceCollection services)
        {
            services.AddTransient<IApplicantService, ApplicantService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IApplicantRepository, ApplicantRepository>();
        }

        private static void ConfigureEntityFramework(IServiceCollection services)
        {
            var databaseName = "ApplicantDB";

           services.AddDbContext<Models.ApplicantDbContext>(options =>
                options.UseInMemoryDatabase(databaseName));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicatonProcess.December2020.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}