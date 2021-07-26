using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Configuration
{
    public static class Log
    {

        public static void CreateLog(string strLog)
        {
            try
            {
                
                string fileName = Utility.Config.Server.LogPath + DateTime.Now.Date.ToString("yyyy-mm-dd") + ".txt";

                if (!Directory.Exists(Utility.Config.Server.LogPath))
                {
                    Directory.CreateDirectory(Utility.Config.Server.LogPath);
                }

                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
             
           
                strLog += "--" + DateTime.Now.Date.ToString("yyyy-mm-dd hh:mm:ss");
                File.AppendAllText(fileName, strLog+Environment.NewLine);

            }
            catch (Exception ex)
            {

            }

        }
    }
}
