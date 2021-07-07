using BaseService.Core;
using BaseService.Data;
using BaseService.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseService.Api.Installers
{
    public static class ServiceExtension
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddConfigurations(this IServiceCollection services)
        {
            services.AddSingleton(FileReaderService.GetConfig());
        }
    }
}
