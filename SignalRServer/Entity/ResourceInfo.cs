using server.Model.Base;
using System;

namespace server.Entity
{
    public class ResourceInfo :BaseEntity
    {
        public ResourceInfo()
        {
            InsertedDateTime = DateTime.Now;
        }
        public CPUInfo CPUInfo { get; set; }
        public MemoryInfo MemoryInfo { get; set; }
        public DiskInfo DiskInfo { get; set; }
        public ServerInfo ServerInfo { get; set; }
        public EthernetInfo ethernetInfo { get; set; }
        public DateTime InsertedDateTime { get; set; }
    }
}
