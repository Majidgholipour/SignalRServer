using server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Configuration
{
    public static class Utility
    {
        public static ServerConfig Config
        {
            get
            {
                return JsonConvertor.ReadFromJson(@"..\..\ServerConfiguration.json");
            }
        }
    }
}
