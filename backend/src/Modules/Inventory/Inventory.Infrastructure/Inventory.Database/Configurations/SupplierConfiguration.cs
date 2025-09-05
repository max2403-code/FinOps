using Common.Database.Configurations;
using Inventory.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Inventory.Database.Configurations;

public class SupplierConfiguration : GuidBaseConfiguration<SupplierDataModel>
{
    public override void Configure(EntityTypeBuilder<SupplierDataModel> builder)
    {
        base.Configure(builder);

        builder.ToTable("Suppliers");

        // Настройка JSON конвертации для SupplierInfo
        builder.Property(s => s.SupplierInfo)
            .HasColumnName("SupplierInfo") // имя столбца в БД
            .HasColumnType("jsonb")             // тип столбца в PostgreSQL
            .HasConversion(
                // Сериализация: объект → JSON
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                // Десериализация: JSON → объект
                v => JsonSerializer.Deserialize<SupplierInfoDataModel>(v, JsonSerializerOptions.Default)!
            )
            .IsRequired();
    }
}
