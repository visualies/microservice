namespace BaseService.Core.Messages
{
    public interface IMessageService
    {
        void PublishMessage(string queue, string message, string routingKey);
    }
}