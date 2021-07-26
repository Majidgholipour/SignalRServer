using SignalR.Hubs;
using System;
using server.Configuration.Enums;
using server.Data;
using server.Configuration;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp.StartServer();

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("--------Server running on {0} ", Utility.Config.Server.ConncetionURL);
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("--------Press X key for exit---------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------");

            while (true)
            {


                ConsoleKeyInfo ki = Console.ReadKey(true);
                if (ki.Key == ConsoleKey.X)
                {
                    //var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                    //var xx = context.Clients.addMessage("Hello");
                    break;
                }
            }
        }

        public class MyHub : Hub
        {
            Repository repository = new Repository();
            public void Send(string message)
            {
                repository.AddServiceAvailabilityInfo(message);

                Console.WriteLine("Service information is saved at " + DateTime.Now);
                Console.WriteLine("------------------------------------------------------------------");
            }

            public void Receive(ApplicationInput input, string message)
            {
                //var _service = new ResourceService();
                switch (input)
                {
                    case ApplicationInput.ApplicarionInfo:
                        {
                            repository.AddapplicationLog(message);
                            Console.WriteLine("Applicarion information is saved at " + DateTime.Now);
                            Console.WriteLine("------------------------------------------------------------------");
                            break;
                        }
                    case ApplicationInput.ResourceInfo:
                        {
                            repository.AddResourceInfo(message);

                            Console.WriteLine("Resource information is saved at " + DateTime.Now);
                            Console.WriteLine("------------------------------------------------------------------");
                            break;
                        }
                    case ApplicationInput.EventLog:
                        {
                            repository.AddEvelntLog(message);
                            Console.WriteLine("EventLog information is saved at " + DateTime.Now);
                            Console.WriteLine("------------------------------------------------------------------");
                            break;
                        }
                    case ApplicationInput.ServiceAvalibility:
                        {
                            repository.AddServiceAvailabilityInfo(message);
                            Console.WriteLine("Service avalibility information is saved at " + DateTime.Now);
                            Console.WriteLine("------------------------------------------------------------------");
                            break;
                        }
                }


            }
            public void DoSomething(string param)
            {
                Clients.addMessage("majid gholipour");
            }
        }
    }
}
