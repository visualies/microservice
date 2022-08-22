using BaseService.Core.Entities.Example;
using RabbitMQ.Client;

namespace BaseService.Services.Messages
{
    public class ExampleConsumer : ConsumerBase<Example>
    {
        public ExampleConsumer(IConnectionFactory factory) : base(factory, "queue")
        {

        }

        protected override void Subscribe(Example example)
        {

        }
    }
}