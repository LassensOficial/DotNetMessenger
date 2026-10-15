using Microsoft.AspNetCore.Mvc;
using DotNetMessenger.Domain.Entities;
using MediatR;

[ApiController]
[Route("api/user")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpPost("profile")]
    public async Task<IActionResult> GetProfile([FromBody] RequestGetProfile request)
    {
        User user = await sender.Send(new GetUserProfileCommand(request.id));
        
    }
}

public record RequestGetProfile(int id);