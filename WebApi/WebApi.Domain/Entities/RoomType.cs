namespace WebApi.Domain.Entities;

public class RoomType
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string Currency { get; set; }
    public int MinPersonCount { get; set; }
    public int MaxPersonCount { get; set; }
    public List<string> Services { get; set; } = [];
    public List<string> Amenities { get; set; } = [];

    public void Update(RoomType roomType)
    {
        PropertyId = roomType.PropertyId;
        Name = roomType.Name;
        DailyPrice = roomType.DailyPrice;
        Currency = roomType.Currency;
        MinPersonCount = roomType.MinPersonCount;
        MaxPersonCount = roomType.MaxPersonCount;
        Services = roomType.Services;
        Amenities = roomType.Amenities;
    }

    public string ServicesString
    {
        get => string.Join( ',', Services );
        set => Services = value?.Split( ',', StringSplitOptions.RemoveEmptyEntries ).ToList()
                          ?? new List<string>();
    }

    public string AmenitiesString
    {
        get => string.Join( ',', Amenities );
        set => Amenities = value?.Split( ',', StringSplitOptions.RemoveEmptyEntries ).ToList()
                           ?? new List<string>();
    }
}