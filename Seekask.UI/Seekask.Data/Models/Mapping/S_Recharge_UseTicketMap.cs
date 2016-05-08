using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class S_Recharge_UseTicketMap : EntityTypeConfiguration<S_Recharge_UseTicket>
    {
        public S_Recharge_UseTicketMap()
        {
            // Primary Key
            this.HasKey(t => t.SerialNo);

            // Properties
            this.Property(t => t.UseTicketPwd)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.UseTicketType)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.UseStatus)
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
            this.ToTable("S_Recharge_UseTicket");
            this.Property(t => t.SerialNo).HasColumnName("SerialNo");
            this.Property(t => t.UseTicketPwd).HasColumnName("UseTicketPwd");
            this.Property(t => t.UseTicketType).HasColumnName("UseTicketType");
            this.Property(t => t.UseStatus).HasColumnName("UseStatus");
            this.Property(t => t.UseTicketAmount).HasColumnName("UseTicketAmount");
            this.Property(t => t.UseAmount).HasColumnName("UseAmount");
            this.Property(t => t.ValidityStart).HasColumnName("ValidityStart");
            this.Property(t => t.ValidityEnd).HasColumnName("ValidityEnd");
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
