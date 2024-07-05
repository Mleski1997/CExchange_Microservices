using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly Rabbit _rabbitMqService;

    public MessagesController()
    {
        _rabbitMqService = new Rabbit();
    }

    [HttpPost]
    public IActionResult Post([FromBody] string message)
    {
        _rabbitMqService.PublishMessage(message, "test_queue");
        return Ok("Message sent to RabbitMQ");
    }
}