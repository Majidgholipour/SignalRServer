using Newtonsoft.Json;
using server.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Configuration
{
    public static class JsonConvertor
    {
        public static string DataToJsan(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings()
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
        public static T JsonToData<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings()
            { TypeNameHandling = TypeNameHandling.All });
        }

         public static List<T> JsonToDataGenerice<T>(string data)
        {
            return JsonConvert.DeserializeObject<List<T>>(data, new JsonSerializerSettings()
            { TypeNameHandling = TypeNameHandling.All });
        }

        public static ServerConfig ReadFromJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {

                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<ServerConfig>(json);
            }
        }

    }
}
