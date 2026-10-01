using DotNetMessenger.Domain.Entities;
using MediatR;

public record GetChatUserCommand(string SessionKey, int Id) : IRequest<Chat>;