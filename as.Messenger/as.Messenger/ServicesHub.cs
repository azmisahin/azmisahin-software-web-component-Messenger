using @as.Messenger.Models;
using Microsoft.AspNet.SignalR;
/// <summary>
/// Services Messenger
/// </summary>
namespace BetSoft.Services.Messenger
{
    /// <summary>
    /// Services Hub Messenger
    /// </summary>
    public class ServicesHub : Hub
    {
        /// <summary>
        /// Services Singal Update
        /// </summary>
        /// <param name="model"></param>
        public void ServicesSignal(SignalModel model)
        {
            model.id = Context.ConnectionId;
            Clients.AllExcept(model.id).servicesUpdate(model);
            Clients.All.broadcastMessage(model);
        }
    }
}