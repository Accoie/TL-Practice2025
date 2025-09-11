namespace WebApi.Domain.Entities;

public class Property
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public void Update( Property property )
    {
        Name = property.Name;
        Country = property.Country;
        City = property.City;
        Address = property.Address;
        Latitude = property.Latitude;
        Longitude = property.Longitude;
    }
}