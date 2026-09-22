using Microsoft.AspNetCore.Mvc;
using MediatR;
using DotNetMessenger.Application.Commands;

[ApiController]
[Route("api/[controller]")]
public class ChatsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GiveChats()
    {
        
    }
}