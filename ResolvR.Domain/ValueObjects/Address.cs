using ResolvR.Domain.Primitives;

namespace ResolvR.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    public string Street { get; }
    public string PostalCode { get; }
    public string City { get; }
    public string Country { get; }

    public Address(string street, string postalCode, string city, string country)
    {
        Street = street;
        PostalCode = postalCode;
        City = city;
        Country = country;
    }

    private Address()
    {
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Street;
        yield return PostalCode;
        yield return City;
        yield return Country;
    }
}