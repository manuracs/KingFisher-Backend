using KingFisher.Domain.Models.FishFarms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.EntityConfigurations.FishFarms;

public class FishFarmEmployeeConfiguration : IEntityTypeConfiguration<FishFarmEmployee>
{
	public void Configure(EntityTypeBuilder<FishFarmEmployee> builder)
	{
		ArgumentNullException.ThrowIfNull(builder);

		builder.ToTable("FishFarmEmployees");

		builder.HasKey(x => x.Id);

		builder.Property(e => e.EmployeeId).IsRequired();
		builder.Property(e => e.FishFarmId).IsRequired();

		builder.Property(e => e.CertificationExpiryDate)
			.HasColumnType("datetime2")
			.IsRequired();
	}
}
