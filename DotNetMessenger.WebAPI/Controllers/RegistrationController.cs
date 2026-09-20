using Microsoft.AspNetCore.Mvc;

namespace DotNetMessenger.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RegisterUserRequest request)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}

public record RegisterUserRequest(string Name, string Password);
