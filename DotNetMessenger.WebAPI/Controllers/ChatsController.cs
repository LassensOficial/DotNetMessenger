using Microsoft.AspNetCore.Mvc;
using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class ChatsController(ISender sender) : ControllerBase
{
    [HttpPost("GetChats")]
    public async Task<IActionResult> GetChats([FromBody] GetChatsRequest request, CancellationToken cancellationToken)
        => Ok(await sender.Send(new GetChatsUserCommand(request.SessionKey)));

    [HttpPost("GetChat")]
    public async Task<IActionResult> GetChat([FromBody] GetChatRequest request, CancellationToken cancellationToken)
        => Ok(await sender.Send(new GetChatUserCommand(request.SessionKey, request.Id)));

    [HttpPost("CreateChat")]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatRequest request, CancellationToken cancellationToken)
        => Ok(await sender.Send(new CreateChatCommand(request.SessionKey, request.TargetUsername)));

    [HttpPost("SendMessage")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request, CancellationToken cancellationToken)
        => Ok(await sender.Send(new SendMessangeCommand(request.SessionKey, request.Message)));
}

public record GetChatsRequest(string SessionKey);
public record GetChatRequest(string SessionKey, int Id);
public record CreateChatRequest(string SessionKey, string TargetUsername);
public record SendMessageRequest(string SessionKey, Message Message);