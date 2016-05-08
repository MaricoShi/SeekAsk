using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class S_Recharge_OrderMap : EntityTypeConfiguration<S_Recharge_Order>
    {
        public S_Recharge_OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.SerialNo);

            // Properties
            this.Property(t => t.RechargeTime)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.OrderType)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.OrderStatus)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.RechargePhoneNo)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.RechargeProv)
                .HasMaxLength(50);

            this.Property(t => t.RechargeCity)
                .HasMaxLength(50);

            this.Property(t => t.DebitNo)
                .HasMaxLength(32);

            this.Property(t => t.ApiDebitNo)
                .HasMaxLength(50);

            this.Property(t => t.RechargeBackInfo)
                .HasMaxLength(1000);

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
            this.ToTable("S_Recharge_Order");
            this.Property(t => t.SerialNo).HasColumnName("SerialNo");
            this.Property(t => t.RechargeTime).HasColumnName("RechargeTime");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            this.Property(t => t.RechargeCardNo).HasColumnName("RechargeCardNo");
            this.Property(t => t.RechargeBillsNo).HasColumnName("RechargeBillsNo");
            this.Property(t => t.RechargePhoneNo).HasColumnName("RechargePhoneNo");
            this.Property(t => t.RechargeProv).HasColumnName("RechargeProv");
            this.Property(t => t.RechargeCity).HasColumnName("RechargeCity");
            this.Property(t => t.BillsAmount).HasColumnName("BillsAmount");
            this.Property(t => t.SalesAmount).HasColumnName("SalesAmount");
            this.Property(t => t.ActualSalesAmount).HasColumnName("ActualSalesAmount");
            this.Property(t => t.ActualPaymentAmount).HasColumnName("ActualPaymentAmount");
            this.Property(t => t.DebitNo).HasColumnName("DebitNo");
            this.Property(t => t.ApiDebitNo).HasColumnName("ApiDebitNo");
            this.Property(t => t.RechargeBackInfo).HasColumnName("RechargeBackInfo");
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
                .WithMany(t => t.S_Recharge_Order)
                .HasForeignKey(d => d.RechargeBillsNo);
            this.HasRequired(t => t.S_Recharge_CardList)
                .WithMany(t => t.S_Recharge_Order)
                .HasForeignKey(d => d.RechargeCardNo);

        }
    }
}
