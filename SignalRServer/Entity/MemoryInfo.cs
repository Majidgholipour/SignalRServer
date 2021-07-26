using server.Model.Base;

namespace server.Entity
{
    public class MemoryInfo : BaseEntity
    {
        public float Size { get; set; }
        public float Usage { get; set; }
        public float InUse { get; set; }
        public float Avialible { get; set; }
        public float Cached { get; set; }
        public float Commited { get; set; }
    }
}
