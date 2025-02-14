using EventLoggingAPI.Events;
using EventLoggingAPI.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EventLoggingAPI.Controllers
{

    [ApiController]
    [Route("api/logs")]
    public class LogController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public LogController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogRequest request)
        {
            var logEvent = new
            {
                LogId = Guid.NewGuid(),
                Message = request.Message,
                LogLevel = request.LogLevel,
                Timestamp = DateTime.UtcNow
            };

            await _publishEndpoint.Publish<ILogEvent>(logEvent);

            return Ok(new { Message = "Log enviado para processamento", LogId = logEvent.LogId });
        }
    }
}
