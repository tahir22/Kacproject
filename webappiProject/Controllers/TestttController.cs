//using java.util.logging;
//using Microsoft.ServiceModel.WebSockets;
//using Microsoft.Web.WebSockets;
//using SuperWebSocket;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace webappiProject.Controllers
//{
//    public class TestttController : ApiController
//    {
//        private static WebSocketCollection _chatClients = new WebSocketCollection();
//        private static WebClient _chatClients2 = new WebClient();
//        public HttpResponseMessage Get()
//        {
//            var wsServer = new WebSocketServer();
//            int port = 8088;
//            wsServer.Setup(port);
//            wsServer.NewSessionConnected += WsServer_NewSessionConnected;
//            wsServer.NewMessageReceived += WsServer_NewMessageReceived;
//            wsServer.NewDataReceived += WsServer_NewDataReceived;
//            wsServer.SessionClosed += WsServer_SessionClosed;
//            wsServer.Start();

//            return Request.CreateResponse(HttpStatusCode.OK, "Server is running on port " + port + ". Press ENTER to exit....");

//        }
//        private static void WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
//        {
//            Console.WriteLine("SessionClosed");
//        }

//        private static void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
//        {
//            Console.WriteLine("NewDataReceived");
//        }

//        private static void WsServer_NewMessageReceived(WebSocketSession session, string value)
//        {
//            Console.WriteLine("NewMessageReceived: " + value);
//            if (value == "Hello server")
//            {
//                session.Send("NewMessageReceived: " + value);
//            }
//            else
//            {
//                var c = session.Connection;
//                var c1 = session.Cookies;
//                var c2 = session.Config;
//                var c23 = session.Handshaked;
//                var c3 = session.HttpVersion;
//                var c24 = session.Items;
//                var c241 = session.LastActiveTime;
//                var c242 = session.Logger;
//                var c243 = session.SessionID;
//                _chatClients.Single(x => x.Equals("name")).Send(value);


//                _chatClients.Add(SessionID);
//                //_chatClients.SingleOrDefault(r => ((SocketHandler)r).userName == "udara").Send("Hello udara");
//                //_chatClients.b


//                //session.Send("NewMessageReceived: tahir" + value);
//            }

//        }

//        private static void WsServer_NewSessionConnected(WebSocketSession session)
//        {
//            Console.WriteLine("NewSessionConnected");
//        }
//    }
//}
