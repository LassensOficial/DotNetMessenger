using System.Net.Cache;
using System.Net.Http.Json;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;

namespace DotNetMessenger.BlazorClient.Pages;

public partial class Profile
{
    [Inject] public required NavigationManager NavigationManager { get; set; }
    [Inject] public required User CurrentUser { get; set; }
    [Inject] public required HttpClient HttpClient { get; set; }

    [Parameter] public int Id { get; set; } = default;
    [Parameter] public string SessionKey { get; set; } = string.Empty;

    private string UserName { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        UserName = CurrentUser.CurrentUser == null ? string.Empty : CurrentUser.CurrentUser.UserName;
    }
}