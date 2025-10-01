using Inventory.Database.DataModels.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Configurations.Base;

public abstract class GuidBaseConfiguration<TEntity> : BaseConfiguration<TEntity>
    where TEntity : GuidBaseDataModel
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id)
            .HasColumnName("Id");
    }
}
