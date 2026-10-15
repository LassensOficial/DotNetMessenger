using System.Net.Cache;
using System.Net.Http.Json;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;

namespace DotNetMessenger.BlazorClient.Pages;

public partial class Register
{
    [Inject] public required HttpClient HttpClient { get; set; }
    [Inject] public required User CurrentUser { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private string Name { get; set; }
    private string Password { get; set; }
    private string Notification { get; set; }
    public bool IsSuccess { get; set; } = false;

    private Response user = new Response(0, "", "");

    private async Task RegisterAsync()
    {
        RequestRegister request = new RequestRegister(Name, Password);

        try
        {
            var response = await HttpClient.PostAsJsonAsync("http://138.16.183.198:5166/api/Register", request);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadFromJsonAsync<Response>();

                CurrentUser.CurrentUser = user;

                await AnimRegisterAsync();

                // Перенаправляем на страницу чатов
                NavigationManager.NavigateTo("/chats");
            }
            else
            {
                string exception = await response.Content.ReadAsStringAsync();

                Notification = $"Ошибка: {exception}";
            }
        }
        catch (Exception ex)
        {
            Notification = $"Ошибка: {ex.Message}";
        }
    }

    private async Task GoLoginAsync()
    {
        NavigationManager.NavigateTo("login");
    }
    
    private async Task AnimRegisterAsync()
    {
        IsSuccess = true; // Запускаем анимацию исчезновения карточки и появления галочки
        StateHasChanged(); // Принудительно обновляем UI

        // Ждем 2.5 секунды, чтобы пользователь насладился анимацией
        await Task.Delay(2500);
    }
    
}

public record RequestRegister(string Name, string Password);