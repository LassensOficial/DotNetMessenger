using Microsoft.AspNetCore.Mvc;
using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;

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
        try
        {
            User user = await sender.Send(new RegisterUserCommand
            (
                request.Name,
                request.Password
            ), cancellationToken);

            Response response = new Response(user.Id, user.UserName, user.SessionKey);

            return Ok(response);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public record RegisterUserRequest(string Name, string Password);

public record Response(int Id, string UserName, string SessionKey);