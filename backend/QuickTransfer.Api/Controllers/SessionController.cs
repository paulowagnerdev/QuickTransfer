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
    public async Task<IActionResult> CreateSession()
    {
        var response = await _serviceSession.CreateSessionAsync();

        if (!response.IsSuccess)
        {
            return BadRequest(response.Message);
        }
        
        return Ok(response);
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetSession([FromQuery] Guid id)
    {
        var response = await _serviceSession.GetSessionAsync(id);
        return Ok("Get Session");
    }

    [HttpDelete]
    [Route("{Id}")]
    public IActionResult DeleteSession()
    {
        return Ok("das");
    }
}