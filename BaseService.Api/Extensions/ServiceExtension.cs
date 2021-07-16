using BaseService.Core;
using BaseService.Core.Messages;
using BaseService.Data;
using BaseService.Services.Messages;
using BaseService.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace BaseService.Api.Extensions
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

        public static void AddMessageQueue(this IServiceCollection services)
        {
            var config = FileReaderService.GetMessagingConfig();
            var factory = new ConnectionFactory()
            {
                HostName = config.Host,
                UserName = config.Username,
                Password = config.Password,
                Port = config.Port,
            };

            services.AddSingleton(factory);

            services.AddHostedService<MessageListener>();
            services.AddTransient<IMessageService, MessageService>();

        }
    }
}
