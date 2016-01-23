using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Seekask.Data.Models.Mapping
{
    public class Szx_Sys_LogMap : EntityTypeConfiguration<Szx_Sys_Log>
    {
        public Szx_Sys_LogMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.LogID)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.LogName)
                .HasMaxLength(100);

            this.Property(t => t.Source)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.RequestUrl)
                .HasMaxLength(500);

            this.Property(t => t.Message)
                .HasMaxLength(2000);

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
            this.ToTable("Szx_Sys_Log");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.LogName).HasColumnName("LogName");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.LevelCode).HasColumnName("LevelCode");
            this.Property(t => t.RequestUrl).HasColumnName("RequestUrl");
            this.Property(t => t.LogDate).HasColumnName("LogDate");
            this.Property(t => t.Message).HasColumnName("Message");
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
