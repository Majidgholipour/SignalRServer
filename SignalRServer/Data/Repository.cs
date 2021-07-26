using server.Configuration;
using server.Entity;
using System;
using System.Linq;
using System.Reflection;

namespace server.Data
{
    public class Repository
    {
        DB context = new DB();
        public bool AddResourceInfo(string JData)
        {
            try
            {
                ResourceInfo obj = JsonConvertor.JsonToData<ResourceInfo>(JData);
                using (var context = new DB())
                {
                    context.resouceInfo.Add(obj);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddEvelntLog(string JData)
        {
            try
            {

                var obj = JsonConvertor.JsonToDataGenerice<EventLog>(JData);
                if (obj.Count > 0)
                {
                    using (var context = new DB())
                    {
                        foreach (var item in obj)
                        {
                            context.EventLogs.Add(item);
                            context.SaveChanges();
                        }

                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddServiceAvailabilityInfo(string JData)
        {
            try
            {
                ServiceAvailabilityInfo obj = JsonConvertor.JsonToData<ServiceAvailabilityInfo>(JData);
                using (var context = new DB())
                {
                    context.serviceAvailabilityInfo.Add(obj);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                string routPath = this.GetType().Name + " - " + MethodBase.GetCurrentMethod().Name;
                Log.CreateLog(routPath + " -- " + ex.Message);
                return false;
            }
        }

        public ServerInfo AddServerInfo(ServerInfo info)
        {
            try
            {

                if (!context.ServerInfo.Where(x => x.LocalIP == info.LocalIP).Any())
                {
                    context.ServerInfo.Add(info);
                    context.SaveChanges();
                }
                return context.ServerInfo.Where(x => x.LocalIP == info.LocalIP).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new ServerInfo();
            }
        }
        public bool AddapplicationLog(string message)
        {
            try
            {

                ApplicationServers application = JsonConvertor.JsonToData<ApplicationServers>(message);


                application.ApplicationLog.ServerInfo=AddServerInfo(application.ServerInfo);
                
                var xx = context.ApplicationLogs.Add(application.ApplicationLog);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
