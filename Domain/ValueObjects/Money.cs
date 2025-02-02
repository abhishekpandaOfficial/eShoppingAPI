namespace eShopping.API.Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public Money(decimal amount, string currency)
    {
        if (amount < 0) throw new ArgumentException("Amount cannot be negative");
        if (string.IsNullOrEmpty(currency)) throw new ArgumentException("Currency cannot be null or empty");

        Amount = amount;
        Currency = currency;
    }
    // Add Money to another Money object (same currency)
    public Money Add(Money other)
    {
        if (other.Currency != Currency)
            throw new InvalidOperationException("Cannot add money with different currencies.");

        return new Money(Amount + other.Amount, Currency);
    }

    // Subtract Money from another Money object (same currency)
    public Money Subtract(Money other)
    {
        if (other.Currency != Currency)
            throw new InvalidOperationException("Cannot subtract money with different currencies.");

        if (other.Amount > Amount)
            throw new InvalidOperationException("Cannot subtract a larger amount from the current amount.");

        return new Money(Amount - other.Amount, Currency);
    }

    // Method to represent the money as a string
    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }

    // Optional: Implement comparison logic, for sorting and comparisons
    public bool Equals(Money other)
    {
        return other != null && Amount == other.Amount && Currency == other.Currency;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Money);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
}