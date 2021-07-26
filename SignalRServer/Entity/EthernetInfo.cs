using server.Model.Base;

namespace server.Entity
{
    public class EthernetInfo:BaseEntity
    {
        public string AdaptorName { get; set; }
        public string DomainName { get; set; }
        public string ConnectionType { get; set; }
        public string IPv4Address { get; set; }
        public string IPv6Address { get; set; }
        public decimal Send { get; set; }
        public decimal Receive { get; set; }
    }
}
