using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Seekask.Data.Models.Mapping;

namespace Seekask.Data.Models
{
    public partial class SeekAskContext : DbContext
    {
        static SeekAskContext()
        {
            Database.SetInitializer<SeekAskContext>(null);
        }

        public SeekAskContext()
            : base("Name=SeekAskContext")
        {
        }
        
        public DbSet<Weixin_Msg_Request> Weixin_Msg_Request { get; set; }
        public DbSet<Weixin_Sys_Info> Weixin_Sys_Info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Weixin_Msg_RequestMap());
            modelBuilder.Configurations.Add(new Weixin_Sys_InfoMap());
        }
    }
}
