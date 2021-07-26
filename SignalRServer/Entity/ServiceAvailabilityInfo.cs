using server.Configuration.Enums;
using server.Model.Base;
using System;

namespace server.Entity
{
    public class ServiceAvailabilityInfo:BaseEntity
    {
        public string Domain { get; set; }
        public string LocalIP { get; set; }
        public string HostName { get; set; }
        public string ServerName { get; set; }
        public ServiceAvalibilityType serviceAvalibilityType { get; set; }
        public DateTime GenerateDateTime { get; set; }
    }
}
