namespace DotNetMessenger.Application.Commands;

using DotNetMessenger.Domain.Entities;
using MediatR;

public record GiveChatsUserCommand(string key) : IRequest<List<Message>>;