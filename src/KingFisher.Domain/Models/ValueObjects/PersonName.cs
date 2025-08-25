using KingFisher.Domain.BaseModels.Abstractions;

namespace KingFisher.Domain.Models.ValueObjects;

public class PersonName : ValueObject<PersonName>
{
	public string FirstName { get; private set; }

	public string LastName { get; private set; }

	private PersonName() { }

	public PersonName(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return FirstName;
		yield return LastName;
	}
}
