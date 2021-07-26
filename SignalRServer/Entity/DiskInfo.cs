using server.Model.Base;

namespace server.Entity
{
    public class DiskInfo : BaseEntity
    {
        public long TotalSize { get; set; }
        public long TotalFreesize { get; set; }
        public long AvailableFreeSpace { get; set; }
        public string DrivesInfo { get; set; }
    }
}
