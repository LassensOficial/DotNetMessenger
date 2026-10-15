using MediatR;
using DotNetMessenger.Domain.Entities;

public record CreateChatCommand(string SessionKey, string TargetUsername) : IRequest<Chat>;