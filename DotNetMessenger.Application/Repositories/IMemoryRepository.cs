namespace DotNetMessenger.Application.Repositories;

public interface IMemoryRepository
{
    Task<byte[]> GetBytesByNameFile(string nameFile, string namePath);
}