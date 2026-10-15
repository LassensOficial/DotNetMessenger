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
    public string Context{ get; set; }

    public ChatDto CurrentChat { get; set; } = new();

    public string GetChatName(List<string> usersNamesInChat, string userName)
    {
        bool isOk = usersNamesInChat.Remove(userName);

        if (isOk)
            return usersNamesInChat.First();
        else
            return "Ошибка";
    }

    protected override async Task OnInitializedAsync()
    {
        SessionKey = CurrentUser.CurrentUser.SessionKey;

        CurrentChat = await GetChatAsync();

        UpdateChatAsync();
    }

    public async Task<ChatDto> GetChatAsync()
    {
        RequestGetChat request = new RequestGetChat(
            SessionKey,
            Id
        );

        var response = await HttpClient.PostAsJsonAsync("http://138.16.183.198:5166/api/Chats/GetChat", request);

        ChatDto chat = await response.Content.ReadFromJsonAsync<ChatDto>();

        return chat;
    }

    public async Task SendMessageAsync()
    {
        RequestSendMessage request = new(
            CurrentUser.CurrentUser.SessionKey,

            new Message()
            {
                ChatId = Id,
                OwnerId = CurrentUser.CurrentUser.Id,
                Context = this.Context,
                CreatedTime = DateTime.UtcNow
            }
        );

        var response = await HttpClient.PostAsJsonAsync("http://138.16.183.198:5166/api/Chats/SendMessage", request);

        CurrentChat = await GetChatAsync();

        Context = string.Empty;
    }

    private async Task UpdateChatAsync()
    {
        while (true)
        {
            await Task.Delay(2000);

            CurrentChat = await GetChatAsync();

            StateHasChanged();
        }
    }
}

public record RequestGetChat(string SessionKey, int Id);
public record RequestSendMessage(string SessionKey, Message Message);