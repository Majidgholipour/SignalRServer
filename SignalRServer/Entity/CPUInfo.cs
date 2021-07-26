using server.Model.Base;
using System;

namespace server.Entity
{
    public class CPUInfo:BaseEntity
    {
        public float UsagePresent { get; set; }
        public int CountOfCore { get; set; }
        public float Speed { get; set; }
        public int CountOfProcessoer { get; set; }
    }

   
}
