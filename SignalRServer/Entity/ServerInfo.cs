using server.Model.Base;
using System;
using System.Collections.Generic;

namespace server.Entity
{
    public class ServerInfo:BaseEntity
    {
        public string Domain { get; set; }
        public string LocalIP { get; set; }
        public string HostName { get; set; }
        public string ServerName { get; set; }
    
        public virtual ICollection<ApplicationLog> ApplicationLogs { get; set; }
        public virtual ICollection<EventLog> EventLogs{ get; set; }
    }
}
