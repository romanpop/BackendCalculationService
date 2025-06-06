using Microsoft.AspNetCore.SignalR;

namespace BackendCalculationService.Notifications;

public class CalculationHub : Hub
{
    public async Task NotifyChange(string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", message);
    }
}
