using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BackendCalculationService.Notifications;

public class CalculationHub : Hub
{
    public async Task NotifyChange(string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", message);
    }
}
