class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string StreetAddress
    {
        get => _streetAddress;
        set => _streetAddress = value;
    }

    public string City
    {
        get => _city;
        set => _city = value;
    }

    public string StateOrProvince
    {
        get => _stateOrProvince;
        set => _stateOrProvince = value;
    }

    public string Country
    {
        get => _country;
        set => _country = value;
    }

    public bool IsInUSA()
    {
        return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               _country.Trim().Equals("United States", StringComparison.OrdinalIgnoreCase) ||
               _country.Trim().Equals("United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFormattedAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
