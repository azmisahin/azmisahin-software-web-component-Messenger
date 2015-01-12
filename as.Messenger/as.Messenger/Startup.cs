using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(@as.Messenger.Startup))]

namespace @as.Messenger
{
    /// <summary>
    /// Owin Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            //app.MapSignalR();
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };
                map.RunSignalR(hubConfiguration);
            });
            app.Run(Server.Web.Start);
        }
    }
}
