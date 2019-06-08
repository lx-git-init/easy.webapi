using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Easy.WebApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Easy.WebApi.Services
{
    public static class DiServiceCollectionExtensions
    {
        /// <summary>
        /// 注入接口服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPrivateConfig(this IServiceCollection services)
        {
            Assembly[] assemblies =
            {
                Assembly.Load("Easy.WebApi.IBll"),
                Assembly.Load("Easy.WebApi.Bll"),
                Assembly.Load("Easy.WebApi.IDal"),
                Assembly.Load("Easy.WebApi.Dal")
            };

            var types = assemblies
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDependency))))
                .ToArray();

            var tmpTypes = types.Where(_ => _.IsClass);
            var didatas = types.Where(t => t.IsInterface)
                .Select(t => new
                {
                    serviceType = t,
                    implementationType = tmpTypes.FirstOrDefault(c => c.GetInterfaces().Contains(t))
                }).ToList();

            didatas.ForEach(t =>
            {
                if (t.implementationType != null)
                    services.AddScoped(t.serviceType, t.implementationType);
            });

            return services;
        }
    }
}
