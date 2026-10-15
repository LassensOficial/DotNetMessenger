using MediatR;
using DotNetMessenger.Domain.Entities;

public record SendMessangeCommand(string SessionKey, Message Message) : IRequest<bool>;