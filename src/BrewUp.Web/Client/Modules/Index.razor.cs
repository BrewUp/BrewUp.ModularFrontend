using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BrewUp.Web.Client.Modules;

public class IndexBase : ComponentBase, IAsyncDisposable
{
    private HubConnection HubConnection { get; set; } = default!;

    protected string Message { get; set; } = string.Empty;
    protected IEnumerable<string> Messages { get; set; } = Enumerable.Empty<string>();

    protected bool IsConnected => HubConnection.State == HubConnectionState.Connected;

    protected override async Task OnInitializedAsync()
    {
        Message = "Welcome to Beer Driven Development";

        // HubConnection = new HubConnectionBuilder()
        //     .WithUrl("http://localhost:5043/device")
        //     .WithAutomaticReconnect()
        //     .Build();

        // HubConnection.On<string, string>("deviceUpdateForAll", (clientId, message) =>
        // {
        //     Message = message;
        //
        //     Messages = Messages.Prepend($"{clientId}: {message}");
        //     StateHasChanged();
        // });

        // await HubConnection.StartAsync();
    }

    #region Dispose
    public async ValueTask DisposeAsync()
    {
        // await HubConnection.DisposeAsync();
    }
    #endregion
}