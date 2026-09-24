using DotNetMessenger.Application.CommandsHandler;

public class SessionKey(ISessionRepository sessionRepository) : ISessionKeyCreate
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

            exists = await sessionRepository.ExistsSessionKey(key);
        }

        return key;
    }
}

public interface ISessionRepository
{
    public Task<bool> ExistsSessionKey(string key);
}