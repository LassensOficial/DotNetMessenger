using Microsoft.AspNetCore.Mvc;
using MediatR;
using DotNetMessenger.Application.Commands;

[ApiController]
[Route("api/[controller]")]
public class ChatsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetChats([FromBody] GetChatsRequest request, CancellationToken cancellationToken) 
        => Ok(await sender.Send(new GiveChatsUserCommand(request.SessionKey)));
}

public record GetChatsRequest(string SessionKey);