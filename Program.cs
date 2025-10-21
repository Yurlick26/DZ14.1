using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; }
    public double BasePrice { get; }
    public double Count { get; }

    public Product(string name, double basePrice, double count = 1)
    {
        Name = name;
        BasePrice = basePrice;
        Count = count;
    }

    public double GetTotalPrice()
    {
        
        if (Name.ToLower() == "potato" || Name.ToLower() == "cucumber")
            return BasePrice * Count;
        else
            return BasePrice;
    }

    public override string ToString()
    {
        if (Name.ToLower() == "potato" || Name.ToLower() == "cucumber")
            return $"Product: {Name}, Price: {BasePrice}, Count: {Count}, Total price: {GetTotalPrice()}";
        else
            return $"Product: {Name}, Price: {GetTotalPrice()}";
    }
}

class VegetableShop
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void PrintProductsInfo()
    {
        double total = 0;
        Console.WriteLine("\n--- Product information ---");
        foreach (var p in products)
        {
            Console.WriteLine(p);
            total += p.GetTotalPrice();
        }
        Console.WriteLine($"Total products price: {total}");
    }
}

class Program
{
    static void Main()
    {
        VegetableShop shop = new VegetableShop();

        while (true)
        {
            Console.Write("Enter the name of the product (Carrot, Potato, Cucumber або stop): ");
            string name = Console.ReadLine();

            if (name.ToLower() == "stop")
                break;

            Console.Write("Enter the product price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Error: You must enter a number!");
                continue;
            }

            double count = 1;
            if (name.ToLower() == "potato" || name.ToLower() == "cucumber")
            {
                Console.Write("Enter the quantity (кг): ");
                if (!double.TryParse(Console.ReadLine(), out count))
                {
                    Console.WriteLine("Error: You must enter a number!");
                    continue;
                }
            }

            shop.AddProduct(new Product(name, price, count));
            Console.WriteLine("✅ Product added!\n");
        }

        shop.PrintProductsInfo();

        Console.WriteLine("\nPress any key to end...");
        Console.ReadKey();
    }
}
