using DotNetMessenger.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoginController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        int userId = await sender.Send(new RegisterUserCommand(request.Name, request.Password), cancellationToken);

        return Ok(userId);
    }
}

public record LoginUserRequest(string Name, string Password);