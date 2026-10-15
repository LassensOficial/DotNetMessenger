using System.Net.Cache;
using System.Net.Http.Json;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;

namespace DotNetMessenger.BlazorClient.Pages;

public partial class Login
{
    [Inject] public required HttpClient HttpClient { get; set; }
    [Inject] public required User CurrentUser { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private string Name { get; set; }
    private string Password { get; set; }
    private string Notification { get; set; }
    public bool IsSuccess { get; set; } = false;

    private Response user = new Response(0, "", "");

    private async Task LoginAsync()
    {
        var request = new RequestLogin(Name, Password);

        try
        {
            var response = await HttpClient.PostAsJsonAsync("http://138.16.183.198:5166/api/Login", request);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadFromJsonAsync<Response>();

                CurrentUser.CurrentUser = user;

                await AnimSeccuessLoginAsync();

                // Перенаправляем в мессенджер
                NavigationManager.NavigateTo("/chats");
            }
            else
            {
                string exception = await response.Content.ReadAsStringAsync();

                Notification = $"Ошибка : {exception}";
            }
        }
        catch (Exception ex)
        {
            Notification = $"Ошибка : {ex.Message}";
        }
    }

    private async Task AnimSeccuessLoginAsync()
    {
        IsSuccess = true; // Запускаем красивый замок!
        StateHasChanged(); // Принудительный рендер анимации

        // Даем замку открыться красиво (2 секунды задержки)
        await Task.Delay(2000);
    }
}

public record RequestLogin(string Name, string Password);