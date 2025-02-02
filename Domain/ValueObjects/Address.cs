namespace eShopping.API.Domain.ValueObjects;

public class Address
{
    public Guid Id { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }

    // Constructor
    public Address(string street, string city, string state, string postalCode, string country)
    {
        if (string.IsNullOrEmpty(street)) throw new ArgumentException("Street cannot be null or empty");
        if (string.IsNullOrEmpty(city)) throw new ArgumentException("City cannot be null or empty");
        if (string.IsNullOrEmpty(state)) throw new ArgumentException("State cannot be null or empty");
        if (string.IsNullOrEmpty(postalCode)) throw new ArgumentException("PostalCode cannot be null or empty");
        if (string.IsNullOrEmpty(country)) throw new ArgumentException("Country cannot be null or empty");

        Id = Guid.NewGuid(); // Assign a unique Id for the address
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    // Method to represent the address as a string
    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {PostalCode}, {Country}";
    }

    // Optional: Implement equality comparisons
    public override bool Equals(object obj)
    {
        return obj is Address address &&
               Id == address.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}