using KingFisher.Domain.Common.Constants;
using KingFisher.Domain.Common.Enums;
using KingFisher.Domain.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.EntityConfigurations.Employees;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		ArgumentNullException.ThrowIfNull(builder);

		builder.ToTable("Employees", t =>
		{
			t.HasCheckConstraint("CK_Employee_Position_Type", $"PositionType IN ({(int)WorkerPositionType.None}, {(int)WorkerPositionType.Worker}, {(int)WorkerPositionType.CEO}, {(int)WorkerPositionType.Captain})");
		});

		builder.OwnsOne(builder => builder.Name, x =>
		{
			x.Property(g => g.FirstName).HasPrecision(DomainConstants.PersonNames.FirstNameLength).HasColumnName("FirstName").IsRequired();
			x.Property(g => g.LastName).HasPrecision(DomainConstants.PersonNames.LastNameLength).HasColumnName("LastName").IsRequired();
		});

		builder.Property(i => i.ProfileImage).HasMaxLength(DomainConstants.Employees.ProfileImageURLLength);
		builder.Property(i => i.Email).HasMaxLength(DomainConstants.Employees.EmailLength).IsRequired();

		builder.Property(e => e.DateOfBirth)
			.HasColumnType("datetime2")
			.IsRequired();

		builder.Property(i => i.PositionType)
			.IsRequired()
			.HasConversion<int>();
	}
}
