namespace WebApi.Domain.Filters;

public class SearchFilter
{
    public string City { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public decimal MaxPrice { get; set; }
    public int PersonCount { get; set; }
}