using Microsoft.AspNetCore.Components;

namespace DotNetMessenger.BlazorClient.Pages;

public partial class Chats
{
    [Inject] public required User CurrentUser { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private string Notification { get; set; }

    private string GetChatName(List<string> usersName, string userName)
    {
        var isOk = usersName.Remove(userName);

        if (isOk)
            return usersName.First();
        else
            return "Ошибка!";
    }

    protected override async Task OnInitializedAsync()
    {
        #region ТЕСТ

        CurrentUser.CurrentUser = new Response(1, "Artyom", "secret");

        Console.WriteLine("че та началося");
        CurrentUser.Chats.Add(new ChatDto
        {
            Id = 1,
            UserNameInChat = ["Artyom", "Ivan"]
        }
        );
        CurrentUser.Chats.Add(new ChatDto
        {
            Id = 2,
            UserNameInChat = ["Egor", "Artyom"]
        }
        );
        CurrentUser.Chats.Add(new ChatDto
        {
            Id = 11111,
            UserNameInChat = ["Helper Chat", "Artyom"]
        }
        );
        #endregion

        //if (currentUser.CurrentUser != null)
        //{
        //    RequestGetChats request = new RequestGetChats(currentUser.CurrentUser.SessionKey);

        //    var response = await httpClient.PostAsJsonAsync("http://localhost:5166/api/Chats", request);

        //    if (response.IsSuccessStatusCode)
        //        currentUser.Chats = (await response.Content.ReadFromJsonAsync<ResponseGetChats>()).Chats;
        //    else
        //        Notification = "Ошибка!";
        //} 
    }

    private void RedirectToChat(int id)
    {
        NavigationManager.NavigateTo($"chats/{id}/chat");
        Console.WriteLine(id);
    }

    private record RequestGetChats(string SessionKey);

    private record ResponseGetChats(List<ChatDto> Chats);
}
