using Common.Database.Configurations;
using Inventory.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Configurations;

public class MeasurementUnitConfiguration : GuidBaseConfiguration<MeasurementUnitDataModel>
{
    public override void Configure(EntityTypeBuilder<MeasurementUnitDataModel> builder)
    {
        base.Configure(builder);

        builder.ToTable("MeasurementUnits");

        builder.Property(i => i.ShortName)
            .HasColumnName("ShortName")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(i => i.FullName)
           .HasColumnName("FullName")
           .HasMaxLength(200)
           .IsRequired();
    }
}
