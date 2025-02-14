using EventLoggingAPI.Events;
using MassTransit;

namespace EventLoggingAPI.Consumers
{
    public class LogEventConsumer : IConsumer<ILogEvent>
    {
        private readonly ILogger<LogEventConsumer> _logger;

        public LogEventConsumer(ILogger<LogEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ILogEvent> context)
        {
            _logger.LogInformation(" Novo log recebido: {LogId} - {Message} - {LogLevel} - {Timestamp}",
                context.Message.LogId, context.Message.Message, context.Message.LogLevel, context.Message.Timestamp);

            return Task.CompletedTask;
        }
    }
}
