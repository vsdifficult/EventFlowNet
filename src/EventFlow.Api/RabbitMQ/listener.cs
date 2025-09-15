using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using EventFlow.Models.Contracts.ReportResponses;

namespace EventFlow.Api.RabbitMq.Listener; 

public class ReportCompletedListener
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public ReportCompletedListener()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: "report-completed", durable: true, exclusive: false, autoDelete: false, arguments: null);
    }

    public void Start()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonSerializer.Deserialize<ReportCompleted>(Encoding.UTF8.GetString(body));

            if (message != null)
            {
                Console.WriteLine($"[API] Отчёт {message.ReportId} готов: {message.FileUrl}");
                // здесь обновляем ReportEntity в БД (Status = Completed)
            }
        };

        _channel.BasicConsume(queue: "report-completed", autoAck: true, consumer: consumer);
    }
}
