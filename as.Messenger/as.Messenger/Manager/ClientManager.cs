using System;
using System.Configuration;
using Microsoft.AspNet.SignalR.Client;
using @as.Messenger.Models;

namespace @as.Messenger
{
    /// <summary>
    /// Messenger Manager
    /// </summary>
    public class ClientManager
    {
        /// <summary>
        /// Signal Server Uri
        /// </summary>
        private string uri { get;set; }

        /// <summary>
        /// Client Proxy
        /// </summary>
        private IHubProxy hubProxy { get; set; }

        /// <summary>
        /// Client Connection
        /// </summary>
        private HubConnection hubConnection { get; set; }

        /// <summary>
        /// Client Manager
        /// </summary>
        public ClientManager()
        {
            uri = getAppKey("Messenger.SignalServer");
        }

        /// <summary>
        /// Send Signal Server By Model
        /// </summary>
        /// <param name="model"></param>
        public void sendSignal(SignalModel model)
        {
                hubConnection = new HubConnection(uri);
                hubConnection.Closed += HubConnection_Closed;
                hubProxy = hubConnection.CreateHubProxy("ServicesHub");           
                hubConnection.Start().Wait();
                hubProxy.Invoke("ServicesSignal", model).Wait();
        }

        /// <summary>
        /// Hub Connection Closed
        /// </summary>
        private void HubConnection_Closed()
        {
            Console.WriteLine("HubConnection_Closed");
        }

        #region Configuration
        /// <summary>
        /// Application Key
        /// </summary>
        /// <param name="key">appSettings Key</param>
        /// <returns>value</returns>
        public static string getAppKey(string key)
        {
            var value = ConfigurationManager.AppSettings[key].ToString();
            return value;
        }
        #endregion
    }
}