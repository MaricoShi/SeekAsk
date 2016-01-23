using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Seekask.Data.Models.Mapping;

namespace Seekask.Data.Models
{
    public partial class SeekAskContext : DbContext
    {
        static SeekAskContext()
        {
            //�޳�ʼ����Ϊ
            Database.SetInitializer<SeekAskContext>(null);  

            //û�����ݿ�ʱ���� Ĭ����Ϊ
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SeekAskContext>());

            //ģ�͸ı�ʱ���Զ����´���һ���µ����ݿ�
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SeekAskContext>());
            //ÿ������ʱ�������������ݿ�
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
