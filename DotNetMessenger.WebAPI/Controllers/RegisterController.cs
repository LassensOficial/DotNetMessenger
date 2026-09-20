using Microsoft.AspNetCore.Mvc;
using MediatR;
using DotNetMessenger.Application.Commands;

namespace DotNetMessenger.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        int userId = await sender.Send(new RegisterUserCommand
        (
            request.Name,
            request.Password
        ), cancellationToken);

        return Ok(userId);
    }
}

public record RegisterUserRequest(string Name, string Password);