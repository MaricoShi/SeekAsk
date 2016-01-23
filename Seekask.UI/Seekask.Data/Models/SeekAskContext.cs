using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Seekask.Data.Models.Mapping;

namespace Seekask.Data.Models
{
    public partial class SeekAskContext : DbContext
    {
        static SeekAskContext()
        {
            //无初始化行为
            Database.SetInitializer<SeekAskContext>(null);  

            //没有数据库时创建 默认行为
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SeekAskContext>());

            //模型改变时，自动重新创建一个新的数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SeekAskContext>());
            //每次运行时都重新生成数据库
            //Database.SetInitializer(new DropCreateDatabaseAlways<SeekAskContext>());
            
        }

        public SeekAskContext()
            : base("Name=SeekAskContext")
        {
            
        }

        public DbSet<Szx_Sys_Log> Szx_Sys_Log { get; set; }
        public DbSet<Weixin_Msg_Request> Weixin_Msg_Request { get; set; }
        public DbSet<Weixin_Sys_Info> Weixin_Sys_Info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Szx_Sys_LogMap());
            modelBuilder.Configurations.Add(new Weixin_Msg_RequestMap());
            modelBuilder.Configurations.Add(new Weixin_Sys_InfoMap());
        }
    }
}
