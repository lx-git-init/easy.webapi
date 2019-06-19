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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services, IHostingEnvironment env)
        {
            services.AddMvc(opts =>
                {
                    opts.ModelMetadataDetailsProviders.Add(new RequiredBindingMetadataProvider());
                    opts.Filters.Add(new ActionResultFilter(env));
                    opts.Filters.Add(new ApiExceptionFilter(env));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MyDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:default"]));

            services.AddMiniProfiler();

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

            app.UseMiniProfiler();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}