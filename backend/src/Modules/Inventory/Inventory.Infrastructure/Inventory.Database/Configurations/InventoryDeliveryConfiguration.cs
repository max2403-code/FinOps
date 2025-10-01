using Inventory.Database.Configurations.Base;
using Inventory.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Configurations;

public class InventoryDeliveryConfiguration : GuidBaseConfiguration<InventoryDeliveryDataModel>
{
    public override void Configure(EntityTypeBuilder<InventoryDeliveryDataModel> builder)
    {
        base.Configure(builder);

        builder.ToTable("InventoryDeliveries");

        builder.Property(d => d.Number)
            .HasColumnName("Number")
            .IsRequired();

        builder.Property(d => d.InventoryItemId)
            .HasColumnName("InventoryItemId")
            .IsRequired();

        builder.Property(d => d.SupplierId)
            .HasColumnName("SupplierId")
            .IsRequired();

        builder.Property(d => d.MeasurementUnitId)
            .HasColumnName("MeasurementUnitId")
            .IsRequired();

        builder.Property(d => d.Quantity)
            .HasColumnName("Quantity")
            .HasColumnType("decimal(18,3)") // 18 цифр, 3 после запятой
            .IsRequired();

        builder.Property(d => d.TotalCost)
            .HasColumnName("TotalCost")
            .HasColumnType("decimal(18,2)") // 18 цифр, 2 после запятой
            .IsRequired();

        builder.Property(d => d.DeliveryDate)
            .HasColumnName("DeliveryDate")
            .IsRequired();

        builder.Property(d => d.Comment)
            .HasColumnName("Comment")
            .HasMaxLength(2000);

        // Связи
        builder.HasOne(d => d.InventoryItem)
            .WithMany() 
            .HasForeignKey(d => d.InventoryItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Supplier)
            .WithMany() 
            .HasForeignKey(d => d.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.MeasurementUnit)
            .WithMany() 
            .HasForeignKey(d => d.MeasurementUnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
