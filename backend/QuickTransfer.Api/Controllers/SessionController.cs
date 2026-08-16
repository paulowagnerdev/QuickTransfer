using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace QuickTransfer.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _serviceSession;

    public SessionController(ISessionService serviceSession)
    {
        _serviceSession = serviceSession;
    }
    
    [HttpPost]
    public IActionResult CreateSession()
    {
        var newSession = _serviceSession.CreateSession();
        return Ok("Recebi a requisição");
    }
    
    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetSession()
    {
        return Ok("Get Session");
    }

    [HttpDelete]
    [Route("{Id}")]
    public IActionResult DeleteSession()
    {
        return Ok("das");
    }
}