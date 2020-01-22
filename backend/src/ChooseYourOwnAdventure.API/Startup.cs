using AutoMapper;
using ChooseYourOwnAdventure.API.Filters;
using ChooseYourOwnAdventure.Application.Mapping;
using ChooseYourOwnAdventure.Application.Query;
using ChooseYourOwnAdventure.Domain.Repositories;
using ChooseYourOwnAdventure.Infrastructure;
using ChooseYourOwnAdventure.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Neo4jClient;
using System;

namespace ChooseYourOwnAdventure.API
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
            services.Configure<Neo4jConfiguration>(Configuration.GetSection("Neo4j"));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(o => true)
                        .Build();
                    });
            });


            services.AddControllers(cfg =>
            {
                cfg.Filters.Add(typeof(ErrorHandlingFilter));
            });

            services.AddSingleton<IFactory<GraphClient>, ConnectionFactory>();
            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<IStepRepository, StepRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.Load("ChooseYourOwnAdventure.Application"));
            services.AddMediatR(AppDomain.CurrentDomain.Load("ChooseYourOwnAdventure.Application"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
