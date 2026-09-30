using DotNetMessenger.Application.Commands;
using DotNetMessenger.Application.Exceptions;
using DotNetMessenger.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoginController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            User user = await sender.Send(new LoginUserCommand(request.Name, request.Password), cancellationToken);

            Response response = new Response(user.Id, user.UserName, user.SessionKey);

            return Ok(response);
        }
        catch (RequestValidationException ex)
        {
            foreach ((string property, string[] messages) in ex.Errors)
            {
                foreach (string message in messages)
                    ModelState.AddModelError(property, message);
            }

            return ValidationProblem(ModelState);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public record LoginUserRequest(string Name, string Password);

public record Response(int Id, string UserName, string SessionKey);