using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Order usaOrder = new Order(
            new Customer(
                "Alice Johnson",
                new Address("742 Evergreen Terrace", "Springfield", "IL", "USA")),
            new List<Product>
            {
                new Product("Wireless Mouse", "WM-100", 24.99m, 1),
                new Product("Mechanical Keyboard", "MK-205", 79.50m, 1),
                new Product("USB-C Cable", "UC-310", 8.99m, 2)
            });

        Order internationalOrder = new Order(
            new Customer(
                "Daniel Moyo",
                new Address("12 Nelson Mandela Ave", "Harare", "Harare Province", "Zimbabwe")),
            new List<Product>
            {
                new Product("Laptop Stand", "LS-410", 32.75m, 1),
                new Product("Noise Cancelling Headphones", "NH-520", 119.99m, 1),
                new Product("Webcam Cover Pack", "WC-615", 4.50m, 3)
            });

        DisplayOrderDetails("Order 1", usaOrder);
        Console.WriteLine(new string('-', 40));
        DisplayOrderDetails("Order 2", internationalOrder);
    }

    static void DisplayOrderDetails(string orderTitle, Order order)
    {
        Console.WriteLine(orderTitle);
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine();
    }
}
