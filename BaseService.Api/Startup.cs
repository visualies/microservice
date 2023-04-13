using BaseService.Api.Assembly;
using BaseService.Api.Extensions;
using BaseService.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaseService.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddUnitOfWork(_configuration.GetSection("Database").Get<DatabaseConfig>());
            services.AddRabbitMQ(_configuration.GetSection("RabbitMQ").Get<RabbitMqConfig>());
            services.AddAppServices();
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddRouteConstraints();
            services.AddControllers();
            services.AddAutoMapper(typeof(ApiAssembly));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.InitializeDatabase();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.AddMappings();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
