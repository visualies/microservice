﻿using BaseService.Core;
using BaseService.Core.Entities.Example;
using BaseService.Data.TypeHandlers;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;
using System.Collections.Generic;

namespace BaseService.Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            context.ExampleRepository.EnsureCreated();
            context.Commit();
        }

        public static void AddMappings(this IApplicationBuilder app)
        {
            SqlMapper.RemoveTypeMap(typeof(ulong));
            SqlMapper.AddTypeHandler(new IdTypeHandler());
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            TinyMapper.Bind<Example, ExampleResponse>();
            TinyMapper.Bind<ExampleRequest, Example>();
            TinyMapper.Bind<List<Example>, List<ExampleResponse>>();
        }
    }
}
