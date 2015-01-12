using Microsoft.Owin;
using System.Threading.Tasks;

namespace @as.Messenger.Server
{
    public class Web
    {
        /// <summary>
        /// Web Server Async Start
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task Start(IOwinContext context)
        {
            #region Const
            string RequestPath = string.Empty;
            string data = string.Empty;
            string export = string.Empty;
            #endregion

            #region Request & Export
            RequestPath = (string)context.Environment["owin.RequestPath"];
            data = context.Request.Query["data"];
            export = Page.Index();
            #endregion

            #region Select and Get Content
            switch (RequestPath)
            {
                #region Roting
                case "/":
                    context.Response.ContentType = "text/html";
                    //export = Page.Offline();
                    export = Page.Index();
                    break;
                case "/Welcome":
                    context.Response.ContentType = "text/html";
                    export = Page.Welcome();
                    break;
                case "/Messenger/SignalServer":
                    context.Response.ContentType = "text/html";
                    export = ClientManager.getAppKey("Messenger.SignalServer");
                    break;
                #endregion                
            }
            #endregion

            return context.Response.WriteAsync(export);
        }
    }
}