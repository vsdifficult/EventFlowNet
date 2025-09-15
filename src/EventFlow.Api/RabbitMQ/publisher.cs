using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using EventFlow.Models.Contracts.ReportResponses;

namespace EventFlow.Api.RabbitMq.Publisher; 

public class RabbitMqPublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqPublisher()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: "report-requests",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    public void PublishReportRequested(ReportRequested message)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        _channel.BasicPublish(exchange: "",
                             routingKey: "report-requests",
                             basicProperties: null,
                             body: body);
    }
}
