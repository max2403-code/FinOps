using Common.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Database.Configurations;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseDataModel
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .IsRequired();

        builder.Property(c => c.DeletedAt)
            .HasColumnName("DeletedAt")
           .IsRequired(false);

        // В запросах будут неудаленные записи по умолчанию
        //builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
