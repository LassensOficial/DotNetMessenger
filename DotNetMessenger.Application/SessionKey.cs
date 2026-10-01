using DotNetMessenger.Application.CommandsHandler;

public class SessionKey(ISessionKeyRepository sessionKetRepository) : ISessionKeyCreate
{
    private string _symbols = "QWERTYUIOPASDFGHJKLZXCVBNM123456789!@#$%^&*()_+,.{}";

    public async Task<string> CreateSessionKey()
    {
        string key = "";
        bool exists = true;

        while (exists)
        {
            key = "";
            
            for (int i = 0; i < 64; i++)
            {
                key += _symbols[Random.Shared.Next(0, 51)];
            }

            exists = await sessionKetRepository.ExistsSessionKey(key);
        }

        return key;
    }
}

public interface ISessionKeyRepository
{
    public Task<bool> ExistsSessionKey(string key);
}