using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FuelTrueConfiguration : IEntityTypeConfiguration<FuelTrue>
{
    public void Configure(EntityTypeBuilder<FuelTrue> builder)
    {
        builder.ToTable("FuelTrues").HasKey(ft => ft.Id);

        builder.Property(ft => ft.Id).HasColumnName("Id").IsRequired();
        builder.Property(ft => ft.Name).HasColumnName("Name").IsRequired();
        builder.Property(ft => ft.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ft => ft.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ft => ft.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(b => b.Models);

        builder.HasQueryFilter(ft => !ft.DeletedDate.HasValue);
    }
}