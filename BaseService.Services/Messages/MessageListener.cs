using BaseService.Core.Entities;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseService.Services.Services
{
    public class MessageListener : IHostedService, IDisposable
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public MessageListener(ConnectionFactory factory)
        {
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(" [x] Received {0}", message);
            };

            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            connection.Close();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }

}

