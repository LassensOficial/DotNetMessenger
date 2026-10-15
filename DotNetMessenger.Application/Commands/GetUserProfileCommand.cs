using DotNetMessenger.Domain.Entities;
using MediatR;

public record GetUserProfileCommand(int id, string nameFile, string namePath) : IRequest<User>;