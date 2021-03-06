using System.Threading.Tasks;
using RefMicroServ.WebApi.Models;

namespace RefMicroServ.WebApi.Hubs
{
    /// <summary>
    /// Interface used to define method on the hub that can be
    /// called to send logs messages to all connected clients.
    /// </summary>
    public interface IMessageLogHub
    {
        Task LogMessage(MessageLogModel messageLog);
    }
}