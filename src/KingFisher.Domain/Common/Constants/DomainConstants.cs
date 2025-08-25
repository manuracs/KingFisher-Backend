namespace KingFisher.Domain.Common.Constants;

public static class DomainConstants
{
	public static class FishFarms
	{
		public const int FarmNameLength = 50;
		public const int FarmImageURLLength = 2048;
	}

	public static class GPSPositions
	{
		public const int DecimalPrecision = 9;
		public const int DecimalScale = 4;
	}

	public static class PersonNames
	{
		public const int FirstNameLength = 50;
		public const int LastNameLength = 50;
	}

	public static class Employees
	{
		public const int ProfileImageURLLength = 2048;
		public const int EmailLength = 320; // based on https://datatracker.ietf.org/doc/html/rfc5321#section-4.5.3.1.1
	}
}
