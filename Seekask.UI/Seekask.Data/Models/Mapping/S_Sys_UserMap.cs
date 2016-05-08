using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class S_Sys_UserMap : EntityTypeConfiguration<S_Sys_User>
    {
        public S_Sys_UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserCode);

            // Properties
            this.Property(t => t.UserCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.UserPwd)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.UserStatus)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            this.Property(t => t.CreateEmpCode)
                .HasMaxLength(32);

            this.Property(t => t.CreateEmpName)
                .HasMaxLength(50);

            this.Property(t => t.CreateIP)
                .HasMaxLength(32);

            this.Property(t => t.ModifyEmpCode)
                .HasMaxLength(32);

            this.Property(t => t.ModifyEmpName)
                .HasMaxLength(50);

            this.Property(t => t.ModifyIP)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("S_Sys_User");
            this.Property(t => t.UserCode).HasColumnName("UserCode");
            this.Property(t => t.UserPwd).HasColumnName("UserPwd");
            this.Property(t => t.UserStatus).HasColumnName("UserStatus");
            this.Property(t => t.UserLevel).HasColumnName("UserLevel");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateEmpCode).HasColumnName("CreateEmpCode");
            this.Property(t => t.CreateEmpName).HasColumnName("CreateEmpName");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreateIP).HasColumnName("CreateIP");
            this.Property(t => t.ModifyEmpCode).HasColumnName("ModifyEmpCode");
            this.Property(t => t.ModifyEmpName).HasColumnName("ModifyEmpName");
            this.Property(t => t.ModifyDate).HasColumnName("ModifyDate");
            this.Property(t => t.ModifyIP).HasColumnName("ModifyIP");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
