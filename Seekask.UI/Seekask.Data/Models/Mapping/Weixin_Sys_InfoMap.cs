using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class Weixin_Sys_InfoMap : EntityTypeConfiguration<Weixin_Sys_Info>
    {
        public Weixin_Sys_InfoMap()
        {
            // Primary Key
            this.HasKey(t => t.WxId);

            // Properties
            this.Property(t => t.Wx_AccountId)
                .HasMaxLength(50);

            this.Property(t => t.Wx_HeadImage)
                .HasMaxLength(500);

            this.Property(t => t.Wx_QRCode)
                .HasMaxLength(500);

            this.Property(t => t.Wx_AccountName)
                .HasMaxLength(100);

            this.Property(t => t.Wx_WechatNumber)
                .HasMaxLength(50);

            this.Property(t => t.Wx_Introduces)
                .HasMaxLength(500);

            this.Property(t => t.Wx_PlaceAddress)
                .HasMaxLength(500);

            this.Property(t => t.Wx_SubjectInfo)
                .HasMaxLength(100);

            this.Property(t => t.Wx_LoginEmail)
                .HasMaxLength(50);

            this.Property(t => t.Wx_AppId)
                .HasMaxLength(50);

            this.Property(t => t.Wx_AppSecret)
                .HasMaxLength(50);

            this.Property(t => t.Wx_URL)
                .HasMaxLength(500);

            this.Property(t => t.Wx_Token)
                .HasMaxLength(50);

            this.Property(t => t.Wx_EncodingAESKey)
                .HasMaxLength(50);

            this.Property(t => t.Wx_Access_Token)
                .HasMaxLength(100);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            this.Property(t => t.Create_Id)
                .HasMaxLength(32);

            this.Property(t => t.Create_Name)
                .HasMaxLength(100);

            this.Property(t => t.Create_IP)
                .HasMaxLength(50);

            this.Property(t => t.Modify_Id)
                .HasMaxLength(32);

            this.Property(t => t.Modify_Name)
                .HasMaxLength(100);

            this.Property(t => t.Modify_IP)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Weixin_Sys_Info");
            this.Property(t => t.WxId).HasColumnName("WxId");
            this.Property(t => t.Wx_AccountId).HasColumnName("Wx_AccountId");
            this.Property(t => t.Wx_HeadImage).HasColumnName("Wx_HeadImage");
            this.Property(t => t.Wx_QRCode).HasColumnName("Wx_QRCode");
            this.Property(t => t.Wx_AccountName).HasColumnName("Wx_AccountName");
            this.Property(t => t.Wx_WechatNumber).HasColumnName("Wx_WechatNumber");
            this.Property(t => t.Wx_WechatType).HasColumnName("Wx_WechatType");
            this.Property(t => t.Wx_Introduces).HasColumnName("Wx_Introduces");
            this.Property(t => t.Wx_Authenticate).HasColumnName("Wx_Authenticate");
            this.Property(t => t.Wx_PlaceAddress).HasColumnName("Wx_PlaceAddress");
            this.Property(t => t.Wx_SubjectInfo).HasColumnName("Wx_SubjectInfo");
            this.Property(t => t.Wx_LoginEmail).HasColumnName("Wx_LoginEmail");
            this.Property(t => t.Wx_AppId).HasColumnName("Wx_AppId");
            this.Property(t => t.Wx_AppSecret).HasColumnName("Wx_AppSecret");
            this.Property(t => t.Wx_URL).HasColumnName("Wx_URL");
            this.Property(t => t.Wx_Token).HasColumnName("Wx_Token");
            this.Property(t => t.Wx_EncodingAESKey).HasColumnName("Wx_EncodingAESKey");
            this.Property(t => t.Wx_EncodingAESType).HasColumnName("Wx_EncodingAESType");
            this.Property(t => t.Wx_Access_Token).HasColumnName("Wx_Access_Token");
            this.Property(t => t.Wx_Access_Token_Time).HasColumnName("Wx_Access_Token_Time");
            this.Property(t => t.Wx_Access_Token_Update).HasColumnName("Wx_Access_Token_Update");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.Create_Id).HasColumnName("Create_Id");
            this.Property(t => t.Create_Name).HasColumnName("Create_Name");
            this.Property(t => t.Create_Time).HasColumnName("Create_Time");
            this.Property(t => t.Create_IP).HasColumnName("Create_IP");
            this.Property(t => t.Modify_Id).HasColumnName("Modify_Id");
            this.Property(t => t.Modify_Name).HasColumnName("Modify_Name");
            this.Property(t => t.Modify_Time).HasColumnName("Modify_Time");
            this.Property(t => t.Modify_IP).HasColumnName("Modify_IP");
            this.Property(t => t.Is_Deleted).HasColumnName("Is_Deleted");
        }
    }
}
