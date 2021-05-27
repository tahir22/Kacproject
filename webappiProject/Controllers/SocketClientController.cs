using Microsoft.ServiceModel.WebSockets;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace webappiProject.Controllers
{
    public class SocketClientController : ApiController
    {
        public static int  countuer22 =0;


        public HttpResponseMessage Get()
        {
            string IPAddress2 = HttpContext.Current.Request.UserHostAddress;
            string IP = HttpContext.Current.Request.Params["HTTP_CLIENT_IP"] ?? HttpContext.Current.Request.UserHostAddress;


            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler());
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }

        class ChatWebSocketHandler : Microsoft.Web.WebSockets.WebSocketHandler
        {
            private static WebSocketCollection _chatClients = new WebSocketCollection();
            private static WebClient _chatClients2 = new WebClient();
 
 
    

            public override void OnOpen()
            {
                _chatClients.Add(this);
            }

            public override void OnMessage(string recordType)
            {
                 
                _chatClients.Broadcast(recordType  );

               

                //for (int i = 0; i < 10; i++)
                //{
                //    _chatClients.Broadcast(i.ToString());
                //    System.Threading.Thread.Sleep(1000);
                //}
            }


        }

    }
}
