using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class Weixin_Msg_RequestMap : EntityTypeConfiguration<Weixin_Msg_Request>
    {
        public Weixin_Msg_RequestMap()
        {
            // Primary Key
            this.HasKey(t => new { t.WxId, t.MsgId });

            // Properties
            this.Property(t => t.WxId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MsgId)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.MsgType)
                .HasMaxLength(12);

            this.Property(t => t.FromUserName)
                .HasMaxLength(32);

            this.Property(t => t.ToUserName)
                .HasMaxLength(32);

            this.Property(t => t.Encrypt)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Weixin_Msg_Request");
            this.Property(t => t.WxId).HasColumnName("WxId");
            this.Property(t => t.MsgId).HasColumnName("MsgId");
            this.Property(t => t.MsgType).HasColumnName("MsgType");
            this.Property(t => t.FromUserName).HasColumnName("FromUserName");
            this.Property(t => t.ToUserName).HasColumnName("ToUserName");
            this.Property(t => t.Encrypt).HasColumnName("Encrypt");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.XmlDocument).HasColumnName("XmlDocument");



        }
    }
}
