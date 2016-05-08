using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class S_Recharge_CardListMap : EntityTypeConfiguration<S_Recharge_CardList>
    {
        public S_Recharge_CardListMap()
        {
            // Primary Key
            this.HasKey(t => t.SerialNo);

            // Properties
            this.Property(t => t.SerialNumber)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.RechargeCardPwd)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.RechargeStatus)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.RechargeType)
                .IsRequired()
                .HasMaxLength(4);

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
            this.ToTable("S_Recharge_CardList");
            this.Property(t => t.SerialNo).HasColumnName("SerialNo");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.RechargeCardPwd).HasColumnName("RechargeCardPwd");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(t => t.RechargeStatus).HasColumnName("RechargeStatus");
            this.Property(t => t.RechargeBillsNo).HasColumnName("RechargeBillsNo");
            this.Property(t => t.RechargeType).HasColumnName("RechargeType");
            this.Property(t => t.Bills).HasColumnName("Bills");
            this.Property(t => t.SalesAmount).HasColumnName("SalesAmount");
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

            // Relationships
            this.HasRequired(t => t.S_Recharge_Bills)
                .WithMany(t => t.S_Recharge_CardList)
                .HasForeignKey(d => d.RechargeBillsNo);

        }
    }
}
