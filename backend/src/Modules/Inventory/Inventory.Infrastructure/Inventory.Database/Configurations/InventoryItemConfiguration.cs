using Common.Database.Configurations;
using Inventory.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Configurations;

public class InventoryItemConfiguration : GuidBaseConfiguration<InventoryItemDataModel>
{
    public override void Configure(EntityTypeBuilder<InventoryItemDataModel> builder)
    {
        base.Configure(builder);

        builder.ToTable("InventoryItems");

        builder.Property(i => i.Name)
            .HasColumnName("Name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(i => i.InventoryCategoryId)
            .HasColumnName("InventoryCategoryId")
            .IsRequired();

        builder.HasOne(i => i.InventoryCategory)
            .WithMany(c => c.InventoryItems)
            .HasForeignKey(i => i.InventoryCategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(i => i.InventoryDeliveries)
            .WithOne(d => d.InventoryItem)
            .HasForeignKey(d => d.InventoryItemId);

        // Уникальность имени складской единицы в рамках одной категории
        builder.HasIndex(c => new { c.Name, c.InventoryCategoryId })
            .HasDatabaseName("UX_InventoryItemNameInCategory")
            .IsUnique();
    }
}
