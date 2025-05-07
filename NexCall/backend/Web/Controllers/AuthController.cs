using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPost("verify")]
    public async Task<IActionResult> Verify()
    {
        throw new NotImplementedException();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        throw new NotImplementedException();
    }
}