using Microsoft.AspNetCore.Components;

namespace DotNetMessenger.BlazorClient.Components;

public partial class Chat
{
    [Parameter] public int Id { get; init; } = default;
}
