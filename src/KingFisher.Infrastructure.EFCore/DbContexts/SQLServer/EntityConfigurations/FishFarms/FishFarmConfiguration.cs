using KingFisher.Domain.Common.Constants;
using KingFisher.Domain.Models.FishFarms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.EntityConfigurations.FishFarms;

public class FishFarmConfiguration : IEntityTypeConfiguration<FishFarm>
{
	public void Configure(EntityTypeBuilder<FishFarm> builder)
	{
		ArgumentNullException.ThrowIfNull(builder);

		builder.ToTable("FishFarms");

		builder.HasKey(f => f.Id);

		builder.HasMany(i => i.FishFarmEmployees).WithOne(i => i.FishFarm);

		builder.OwnsOne(builder => builder.GPSPosition, gps =>
		{
			gps.Property(g => g.Latitude).HasPrecision(DomainConstants.GPSPositions.DecimalPrecision, DomainConstants.GPSPositions.DecimalScale).HasColumnName("Latitude").IsRequired();
			gps.Property(g => g.Longitude).HasPrecision(DomainConstants.GPSPositions.DecimalPrecision, DomainConstants.GPSPositions.DecimalScale).HasColumnName("Longitude").IsRequired();
		});

		builder.Property(i => i.FarmName).HasMaxLength(DomainConstants.FishFarms.FarmNameLength);
		builder.Property(i => i.FarmImageURL).HasMaxLength(DomainConstants.FishFarms.FarmImageURLLength);
	}
}
