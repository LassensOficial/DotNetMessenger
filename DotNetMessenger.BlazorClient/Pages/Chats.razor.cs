using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DotNetMessenger.BlazorClient.Pages;

public partial class Chats
{
    [Inject] public required User CurrentUser { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private string Notification { get; set; }
    private string TargetUsername{ get; set; } = string.Empty;

    private bool IsPanelOpen{ get; set; } = false;

    private string GetChatName(List<string> usersName, string userName) // test debug
    {
        var isOk = usersName.Remove(userName);

        if (isOk)
            return usersName.First();
        else
            return "Ошибка!";
    }

    protected override async Task OnInitializedAsync()
    {
        // #region ТЕСТ

        // CurrentUser.CurrentUser = new Response(1, "Artyom", "secret");

        // Console.WriteLine("че та началося");
        // CurrentUser.Chats.Add(new ChatDto
        // {
        //     Id = 1,
        //     UserNameInChat = ["Artyom", "Ivan"]
        // }
        // );
        // CurrentUser.Chats.Add(new ChatDto
        // {
        //     Id = 2,
        //     UserNameInChat = ["Egor", "Artyom"]
        // }
        // );
        // CurrentUser.Chats.Add(new ChatDto
        // {
        //     Id = 11111,
        //     UserNameInChat = ["Helper Chat", "Artyom"]
        // }
        // );
        // #endregion

        if (CurrentUser.CurrentUser != null)
        {
            RequestGetChats request = new RequestGetChats(CurrentUser.CurrentUser.SessionKey);

            Console.WriteLine($"request get chats {request}");

            var response = await HttpClient.PostAsJsonAsync("http://138.16.183.198:5166/api/Chats/GetChats", request);

            if (response.IsSuccessStatusCode)
            {
                CurrentUser.Chats = await response.Content.ReadFromJsonAsync<List<ChatDto>>();

                string strjson = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"RESPONSE GET CHATS: {strjson}");
            }
            else
                Notification = "Ошибка!";
        }
    }

    private void RedirectToChat(int id)
    {
        NavigationManager.NavigateTo($"chats/{id}/chat");
    }

    private void TogglePanel()
    {
        IsPanelOpen = !IsPanelOpen;
        if (!IsPanelOpen)
        {
            TargetUsername = string.Empty;
        }
    }

    // Логика создания чата
    private async Task StartNewChat()
    {
        if (string.IsNullOrWhiteSpace(TargetUsername)) return;

        RequestCreateChat request = new(CurrentUser.CurrentUser.SessionKey, TargetUsername); // йоу даймонд код

        try
        {
            var response = await HttpClient.PostAsJsonAsync("http://138.16.183.198:5166/api/Chats/CreateChat", request);

            ChatDto chat = await response.Content.ReadFromJsonAsync<ChatDto>();

            CurrentUser.Chats.Add(chat);

            TogglePanel();

            NavigationManager.NavigateTo($"/chats/{chat.Id}/chat");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex} ОШИБКА!");
        }
    }

    private record RequestGetChats(string SessionKey);

    private record RequestCreateChat(string SessionKey, string TargetUsername);
}