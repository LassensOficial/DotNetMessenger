using Microsoft.AspNetCore.Mvc;

namespace DotNetMessenger.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyList<UserResponse>> GetUsers()
    {
        var users = new[]
        {
            new UserResponse(1, "alice"),
            new UserResponse(2, "bob")
        };

        return Ok(users);
    }
}

public record UserResponse(int Id, string UserName);
