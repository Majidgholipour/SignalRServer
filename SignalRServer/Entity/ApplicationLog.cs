using server.Configuration.Enums;
using server.Model.Base;
using System;
using System.Collections.Generic;

namespace server.Entity
{
    public class ApplicationLog : BaseEntity
    {
        public string Message { get; set; }
        public string ApplicationName { get; set; }
        public DateTime GeneratedDate { get; set; }
        public LogType LogType { get; set; }
        public Guid? ServerInfo_ID { get; set; }
        public virtual ServerInfo ServerInfo { get; set; }
    }
}
