using System;
using System.Collections.Generic;
using System.Text;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddressString()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }

    public string StreetAddress => _streetAddress;
    public string City => _city;
    public string StateProvince => _stateProvince;
    public string Country => _country;
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}

public class Product
{
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public double GetPricePerUnit()
    {
        return _pricePerUnit;
    }

    public int GetQuantity()
    {
        return _quantity;
    }
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double productsTotal = 0;
        foreach (Product product in _products)
        {
            productsTotal += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;

        return productsTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        packingLabel.AppendLine("--- Packing Label ---");
        foreach (Product product in _products)
        {
            packingLabel.AppendLine($"Product: {product.GetName()} (ID: {product.GetProductId()})");
            packingLabel.AppendLine($"  Quantity: {product.GetQuantity()}");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder shippingLabel = new StringBuilder();
        shippingLabel.AppendLine("--- Shipping Label ---");
        shippingLabel.AppendLine($"Customer Name: {_customer.GetName()}");
        shippingLabel.AppendLine("Shipping Address:");
        shippingLabel.AppendLine(_customer.GetAddress().GetFullAddressString());
        return shippingLabel.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "PROD001", 1200.00, 1));
        order1.AddProduct(new Product("Mouse", "ACC005", 25.00, 2));
        order1.AddProduct(new Product("Keyboard", "ACC002", 75.00, 1));

        Console.WriteLine("----- Order 1 -----");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n---------------------\n");

        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Webcam", "CAM010", 80.00, 1));
        order2.AddProduct(new Product("Microphone", "AUD001", 150.00, 1));

        Console.WriteLine("----- Order 2 -----");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("\n---------------------\n");

        Address address3 = new Address("789 Pine Rd", "Houston", "TX", "USA");
        Customer customer3 = new Customer("Mike Johnson", address3);

        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("USB Drive", "STOR003", 15.00, 5));
        order3.AddProduct(new Product("External HDD", "STOR001", 100.00, 1));
        order3.AddProduct(new Product("Headphones", "AUD005", 120.00, 1));

        Console.WriteLine("----- Order 3 -----");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.CalculateTotalCost():F2}");
        Console.WriteLine("\n---------------------\n");
    }
}