using Easy.WebApi.Models;
using Easy.WebApi.Services.Attributes;
using Easy.WebApi.Services.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easy.WebApi.Services
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(opts =>
                {
                    opts.ModelMetadataDetailsProviders.Add(new RequiredBindingMetadataProvider());
                    opts.Filters.Add(new ActionResultFilter(_env));
                    opts.Filters.Add(new ApiExceptionFilter(_env));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MyDbContext>(opts => opts.UseSqlServer(_configuration["ConnectionStrings:default"]));

            // 使用MiniProfiler插件分析EF
            services
                .AddMiniProfiler(opts => opts.RouteBasePath = "/profiler")
                .AddEntityFramework();

            services.AddPrivateConfig();

            services.AddLocalization();
        }

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
            app.UseMvc();
        }
    }
}