public class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}
