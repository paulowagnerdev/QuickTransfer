using Microsoft.AspNetCore.Mvc;

namespace QuickTransfer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    [HttpPost]
    [Route("{sessionId}/session")]
    public IActionResult CreateMessage()
    {
        return Ok("Recebi a requisição");
    }
    [HttpGet]
    [Route("{sessionId}/session")]
    public IActionResult GetMessage()
    {
        return Ok("Recebi a requisição");
    }
}