using Common.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Database.Configurations;

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
