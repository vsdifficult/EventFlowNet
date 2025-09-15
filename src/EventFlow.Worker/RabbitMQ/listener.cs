using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using EventFlow.Models.Contracts.ReportResponses;

public class ReportWorker
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public ReportWorker()
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

    public void Start()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonSerializer.Deserialize<ReportRequested>(Encoding.UTF8.GetString(body));

            if (message != null)
            {
                Console.WriteLine($"[Worker] Генерация отчета {message.ReportId}...");

                // тут генерируем отчёт (например PDF/Excel)
                var fileUrl = $"/files/{message.ReportId}.pdf";

                // потом можно опубликовать ReportCompleted
                PublishReportCompleted(new ReportCompleted(message.ReportId, fileUrl));
            }
        };

        _channel.BasicConsume(queue: "report-requests",
                             autoAck: true,
                             consumer: consumer);
    }

    private void PublishReportCompleted(ReportCompleted message)
    {
        _channel.QueueDeclare(queue: "report-completed", durable: true, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        _channel.BasicPublish(exchange: "", routingKey: "report-completed", basicProperties: null, body: body);
    }
}
