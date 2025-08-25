namespace KingFisher.Domain.BaseModels.Abstractions;

public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
{
	public abstract IEnumerable<object> GetAtomicValues();

	public bool Equals(T? other)
	{
		return other is not null && GetAtomicValues().SequenceEqual(other.GetAtomicValues());
	}

	public override bool Equals(object? obj)
	{
		return obj is T other && Equals(other);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(GetAtomicValues().ToArray());
	}
}
