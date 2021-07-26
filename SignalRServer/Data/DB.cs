using server.Entity;
using System.Data.Entity;

namespace server.Data
{
    public class DB : DbContext
    {
        public DB() : base("ServerDBConnectionString")
        {

        }
        public DbSet<ResourceInfo> resouceInfo { get; set; }
        public DbSet<CPUInfo> CPUInfo { get; set; }
        public DbSet<MemoryInfo> MemoryInfo { get; set; }
        public DbSet<DiskInfo> DiskInfo { get; set; }
        public DbSet<EthernetInfo> EthernetInfo { get; set; }
        public DbSet<ServerInfo> ServerInfo { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<ServiceAvailabilityInfo> serviceAvailabilityInfo { get; set; }
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }
        //public DbSet<ApplicationServers> ApplicationServers { get; set; }


        protected override void OnModelCreating(DbModelBuilder Builder)
        {
            //Configure domain classes using modelBuilder here..
            #region CPUInfo
            Builder.Entity<CPUInfo>().ToTable("CPUInfo");
            Builder.Entity<CPUInfo>().Property(p => p.Id);
            Builder.Entity<CPUInfo>().Property(p => p.CountOfCore).HasColumnType("Int");
            //Builder.Entity<CPUInfo>().Property(p => p.Speed).HasColumnType("Decimal(18,2)");
            Builder.Entity<CPUInfo>().Property(p => p.CountOfProcessoer).HasColumnType("Int");
            //Builder.Entity<CPUInfo>().Property(p => p.Utilization).HasColumnType("Int");
            #endregion

            #region MemoryInfo
            Builder.Entity<MemoryInfo>().ToTable("MemoryInfo");
            //Builder.Entity<MemoryInfo>().Property
            //Builder.Entity<MemoryInfo>().Property(p => p.Avialible).has;
            //Builder.Entity<MemoryInfo>().Property(p => p.Cached).HasColumnType("Decimal(18,2)");
            //Builder.Entity<MemoryInfo>().Property(p => p.Commited).HasColumnType("Decimal(18,2)");
            //Builder.Entity<MemoryInfo>().Property(p => p.InUse).HasColumnType("Decimal(18,2)");
            //Builder.Entity<MemoryInfo>().Property(p => p.Size).HasColumnType("Decimal(18,2)");
            #endregion

            #region DiskInfo
            Builder.Entity<DiskInfo>().ToTable("DiskInfo");
            //Builder.Entity<DiskInfo>().Property(p => p.Capacity).HasColumnType("Decimal(18,2)");
            //Builder.Entity<DiskInfo>().Property(p => p.FreeSpace).HasColumnType("Decimal(18,2)");
            //Builder.Entity<DiskInfo>().Property(p => p.Usage).HasColumnType("Decimal(18,2)");
            #endregion

            #region EthernetInfo
            Builder.Entity<EthernetInfo>().ToTable("EthernetInfo");
            Builder.Entity<EthernetInfo>().Property(p => p.AdaptorName).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<EthernetInfo>().Property(p => p.ConnectionType).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<EthernetInfo>().Property(p => p.DomainName).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<EthernetInfo>().Property(p => p.IPv4Address).HasColumnType("varchar").HasMaxLength(16);
            Builder.Entity<EthernetInfo>().Property(p => p.IPv6Address).HasColumnType("varchar").HasMaxLength(30);
            //Builder.Entity<EthernetInfo>().Property(p => p.Receive).HasColumnType("Decimal(18,2)");
            //Builder.Entity<EthernetInfo>().Property(p => p.Send).HasColumnType("Decimal(18,2)");
            #endregion


            #region ServerInfo
            Builder.Entity<ServerInfo>().ToTable("ServerInfo");
            //Builder.Entity<ServerInfo>().HasIndex(a => new { a.LocalIP ,a.ServerName}).IsUnique();
            Builder.Entity<ServerInfo>().Property(p => p.Domain).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<ServerInfo>().Property(p => p.HostName).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<ServerInfo>().Property(p => p.LocalIP).HasColumnType("varchar").HasMaxLength(16);
            Builder.Entity<ServerInfo>().Property(p => p.ServerName).HasColumnType("varchar").HasMaxLength(30);
            #endregion

            #region EventLog
            Builder.Entity<EventLog>().ToTable("EventLogs");
            Builder.Entity<EventLog>().Property(p => p.Category).HasColumnType("varchar").HasMaxLength(40);
            Builder.Entity<EventLog>().Property(p => p.Message).HasColumnType("varchar").HasMaxLength(300);
            Builder.Entity<EventLog>().Property(p => p.Source).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<EventLog>().Property(p => p.UserName).HasColumnType("varchar").HasMaxLength(30);
            #endregion
            #region ServiceAvailabilityInfo
            Builder.Entity<ServiceAvailabilityInfo>().ToTable("ServiceAvailabilityInfo");
            Builder.Entity<ServiceAvailabilityInfo>().Property(p => p.Domain).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<ServiceAvailabilityInfo>().Property(p => p.HostName).HasColumnType("varchar").HasMaxLength(30);
            Builder.Entity<ServiceAvailabilityInfo>().Property(p => p.LocalIP).HasColumnType("varchar").HasMaxLength(16);
            Builder.Entity<ServiceAvailabilityInfo>().Property(p => p.ServerName).HasColumnType("varchar").HasMaxLength(30);
            #endregion


            #region ApplicationLog
            Builder.Entity<ApplicationLog>().ToTable("ApplicationLog");
            Builder.Entity<ApplicationLog>().Property(p => p.Message).HasColumnType("NVarChar").HasMaxLength(300);
            Builder.Entity<ApplicationLog>().Property(p => p.LogType).HasColumnType("int");

            Builder.Entity<ServerInfo>()
                         .HasMany(a => a.ApplicationLogs)
                         .WithRequired(a => a.ServerInfo)
                         .HasForeignKey(a => a.ServerInfo_ID);


            Builder.Entity<ServerInfo>()
                         .HasMany(a => a.EventLogs)
                         .WithRequired(a => a.serverInfo)
                         .HasForeignKey(a => a.ServerInfo_ID);


            Database.SetInitializer<DB>(null);
            base.OnModelCreating(Builder);
            #endregion
        }
    }
}
