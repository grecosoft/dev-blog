using Microsoft.AspNetCore.SignalR;

namespace RefMicroServ.WebApi.Hubs
{
    /// <summary>
    /// Hub definition called by HubMessageLogSink to direct all
    /// received message logs to connected clients.
    /// </summary>
    public class MessageLogHub : Hub<IMessageLogHub>
    {
        
    }
}
