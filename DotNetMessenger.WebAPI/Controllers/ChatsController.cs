using Microsoft.AspNetCore.Mvc;
using MediatR;
using DotNetMessenger.Application.Commands;

[ApiController]
[Route("api/[controller]")]
public class ChatsController(ISender sender) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> GiveChats([FromBody] ChatsRequest request, CancellationToken cancellationToken)
    {
        var chats = await sender.Send(new GiveChatsUserCommand(request.SessionKey));

        return Ok(chats);
    }
}

public record ChatsRequest(string SessionKey);