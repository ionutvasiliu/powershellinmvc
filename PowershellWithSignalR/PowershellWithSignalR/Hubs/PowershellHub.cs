using Microsoft.AspNet.SignalR;

namespace PowershellWithSignalR.Hubs
{
    public class PowershellHub : Hub
    {
        public void Send(string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(message);
        }

    }
}