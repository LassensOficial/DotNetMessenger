using System.Net.Cache;
using System.Net.Http.Json;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;

namespace DotNetMessenger.BlazorClient.Components;

public partial class Chat
{
    [Inject] public required NavigationManager NavigationManager { get; set; }
    [Inject] public required User CurrentUser { get; set; }
    [Inject] public required HttpClient HttpClient { get; set; }

    [Parameter] public int Id { get; init; } = default;

    public string SessionKey { get; set; }

    protected override async Task OnInitializedAsync()
    {
        SessionKey = CurrentUser.CurrentUser.SessionKey;
        
        GetChat();
    }

    public async Task<ChatDto> GetChat()
    {
        RequestGetChat request = new RequestGetChat(
            SessionKey,
            Id
        );

        Console.WriteLine(request);

        var response = await HttpClient.PostAsJsonAsync("http://localhost:5166/api/GetChat", request);

        ChatDto chat = (await response.Content.ReadFromJsonAsync<ResponseChat>()).Chat;

        return chat;
    }
}

public record RequestGetChat(string SessionKey, int Id);
public record ResponseChat(ChatDto Chat);