namespace VendingMachine;

// Enum to represent coin types by physical characteristics
    public enum CoinType
    {
        Penny,      // Invalid - rejected
        Nickel,     // Valid - $0.05
        Dime,       // Valid - $0.10
        Quarter     // Valid - $0.25
    }

    // Enum for products
    public enum ProductType
    {
        Cola,
        Chips,
        Candy
    }
public class Product
{
   public string Name { get; set; }
   public decimal Price { get; set; }
   public ProductType Type { get; set; }

    public Product(string name, decimal price, ProductType type)
    {
            Name = name;
            Price = price;
            Type = type;
    } 
}
