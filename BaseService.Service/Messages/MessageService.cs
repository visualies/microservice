﻿using BaseService.Core.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace BaseService.Service.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IModel _channel;

        public MessageService(IConnectionFactory factory)
        {
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void PublishMessage<T>(T payload, string queue, string routingKey)
        {
            PublishMessage(payload, queue, routingKey, "");
        }

        public void PublishMessage<T>(T payload, string queue, string routingKey, string exchange)
        {
            _channel.QueueDeclare(queue: queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = System.Text.Json.JsonSerializer.Serialize(payload);
            var body = Encoding.UTF8.GetBytes(json);
            var properties = _channel.CreateBasicProperties();
            properties.Type = typeof(T).Name;

            _channel.BasicPublish(exchange: exchange,
                routingKey: routingKey,
                basicProperties: properties,
                body: body);
        }
    }
}