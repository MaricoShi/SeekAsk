using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class S_Recharge_DebitMap : EntityTypeConfiguration<S_Recharge_Debit>
    {
        public S_Recharge_DebitMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DebitWay, t.DebitNo });

            // Properties
            this.Property(t => t.DebitWay)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.DebitNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DebitStatus)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.DebitApiInfo)
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
            this.ToTable("S_Recharge_Debit");
            this.Property(t => t.DebitWay).HasColumnName("DebitWay");
            this.Property(t => t.DebitNo).HasColumnName("DebitNo");
            this.Property(t => t.OrderNo).HasColumnName("OrderNo");
            this.Property(t => t.DebitStatus).HasColumnName("DebitStatus");
            this.Property(t => t.DebitApiInfo).HasColumnName("DebitApiInfo");
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
            this.HasRequired(t => t.S_Recharge_Order)
                .WithMany(t => t.S_Recharge_Debit)
                .HasForeignKey(d => d.OrderNo);

        }
    }
}
