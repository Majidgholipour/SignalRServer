using server.Configuration;
using server.Entity;
using SignalR.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public static  class StartUp
    {
        public static string  StartServer()
        {

            try
            {
                ServerConfig cnnObject = JsonConvertor.ReadFromJson(@"..\..\ServerConfiguration.json");
                var server = new Server(cnnObject.Server.ConncetionURL);

                // Map the default hub url (/signalr)
                server.MapHubs();

                // Start the server
                server.Start();
                return cnnObject.Server.ConncetionURL;
            }
            catch (Exception ex)
            {
                return "Connection Faild!";
            }
            
        }
    }
}
