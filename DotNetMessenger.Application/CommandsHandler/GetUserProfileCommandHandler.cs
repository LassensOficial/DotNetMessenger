using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;
using MediatR;

public class GetUserProfileCommandHandler(IUserRepository userRepository, IMemoryRepository memoryRepository) : IRequestHandler<GetUserProfileCommand, User>
{
    public async Task<User> Handle(GetUserProfileCommand command, CancellationToken cancellationToken)
    {
        User user = await userRepository.GetByIdAsync(command.id, cancellationToken);

        byte[] bytes = await memoryRepository.GetBytesByNameFile(command.nameFile, command.namePath);

        user.Bytes = bytes;

        return user;
    }
}