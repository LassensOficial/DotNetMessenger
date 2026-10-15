using MediatR;
using DotNetMessenger.Domain.Entities;

public record CreateChatCommand(List<int> usersIdInChat) : IRequest<Chat>;