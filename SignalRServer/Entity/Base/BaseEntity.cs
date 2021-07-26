using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = System.Guid.NewGuid();
        }
        [Key]
        [DefaultValue("NEWID()")]
        public Guid Id { get; set; }
    }
}
