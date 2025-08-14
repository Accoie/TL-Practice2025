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
}