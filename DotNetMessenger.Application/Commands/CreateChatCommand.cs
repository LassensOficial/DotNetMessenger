using MediatR;

public record CreateChatCommand(string SessionKey, string Name) : IRequest<int>;