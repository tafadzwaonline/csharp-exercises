class Order
{
    private const decimal UsaShippingCost = 5m;
    private const decimal InternationalShippingCost = 35m;

    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public Customer Customer
    {
        get => _customer;
        set => _customer = value;
    }

    public List<Product> Products
    {
        get => _products;
        set => _products = value;
    }

    public decimal CalculateTotalCost()
    {
        decimal subtotal = 0m;

        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA() ? UsaShippingCost : InternationalShippingCost;
        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        List<string> lines = new List<string>();

        foreach (Product product in _products)
        {
            lines.Add($"{product.Name} ({product.ProductId})");
        }

        return string.Join("\n", lines);
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address.GetFormattedAddress()}";
    }
}
