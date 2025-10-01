using Inventory.Database.Configurations.Base;
using Inventory.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Configurations;

public class InventoryCategoryConfiguration : GuidBaseConfiguration<InventoryCategoryDataModel>
{
    public override void Configure(EntityTypeBuilder<InventoryCategoryDataModel> builder)
    {
        base.Configure(builder);

        builder.ToTable("InventoryCategories");

        builder.Property(c => c.CategoryName)
            .HasColumnName("CategoryName")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.HeadInventoryCategoryId)
            .HasColumnName("HeadInventoryCategoryId");

        builder.HasOne(c => c.HeadInventoryCategory)
           .WithMany(c => c.SubInventoryCategories)
           .HasForeignKey(c => c.HeadInventoryCategoryId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.InventoryItems)
            .WithOne(i => i.InventoryCategory)
            .HasForeignKey(i => i.InventoryCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Уникальность имени категории в рамках одного уровня иерархии
        builder.HasIndex(c => new { c.CategoryName, c.HeadInventoryCategoryId })
            .HasDatabaseName("UX_InventoryCategoriesNameParent")
            .IsUnique();

        builder.ToTable(t => t.HasCheckConstraint("CK_InventoryCategoriesNotSelfReference",
            "HeadInventoryCategoryId != id OR HeadInventoryCategoryId IS NULL"));
    }
}
