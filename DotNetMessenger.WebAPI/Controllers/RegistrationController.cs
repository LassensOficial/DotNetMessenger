using Microsoft.AspNetCore.Mvc;
using MediatR;
using DotNetMessenger.Application.Commands;

namespace DotNetMessenger.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        await sender.Send(new RegisterUserCommand
        {
            Name = request.Name,
            Password = request.Password
        }, cancellationToken);

        return Ok();
    }
}

public record RegisterUserRequest(string Name, string Password);
