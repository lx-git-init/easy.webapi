using Easy.WebApi.Models;
using Easy.WebApi.Services.Attributes;
using Easy.WebApi.Services.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling.Storage;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Easy.WebApi.Services
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _env;

        /// <summary>
        ///
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 使用MiniProfiler插件分析EF http://localhost:5000/profiler/results-index
            services.AddMiniProfiler(opts =>
                {
                    opts.RouteBasePath = "/profiler";
                    ((MemoryCacheStorage)opts.Storage).CacheDuration = TimeSpan.FromSeconds(1);
                })
                .AddEntityFramework();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Easy WebApi"
                });
                var xmlMiniProfiler = Path.Combine(AppContext.BaseDirectory, "MiniProfiler.xml");
                options.IncludeXmlComments(xmlMiniProfiler);
                options.IgnoreObsoleteActions();
            });

            services.AddMvc(opts =>
                {
                    opts.ModelMetadataDetailsProviders.Add(new RequiredBindingMetadataProvider());
                    opts.Filters.Add(new ActionResultFilter(_env));
                    opts.Filters.Add(new ApiExceptionFilter(_env));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MyDbContext>(opts => opts.UseSqlServer(_configuration["ConnectionStrings:default"]));
            services.AddPrivateConfig();
            services.AddLocalization();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiniProfiler();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Easy WebApi V1");
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Easy.WebApi.Services.index.html");
            });
            app.UseMvc();
        }
    }
}