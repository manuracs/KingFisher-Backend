using KingFisher.Domain.BaseModels.Abstractions;
using KingFisher.Domain.Common.Constants;

namespace KingFisher.Domain.Models.ValueObjects;

public sealed class GPSPosition : ValueObject<GPSPosition>
{
	public decimal Latitude { get; private set; }

	public decimal Longitude { get; private set; }

	private GPSPosition() { } // This need to create instance by ORM with reflection


	public GPSPosition(decimal latitude, decimal longitude)
	{
		Latitude = Math.Round(latitude, DomainConstants.GPSPositions.DecimalPrecision);
		Longitude = Math.Round(longitude, DomainConstants.GPSPositions.DecimalPrecision);
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Latitude;
		yield return Longitude;
	}
}
