namespace WebApi.Data
{
    public class ReservationUpdationDto
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int PersonCount { get; set; }
        public string GuestName { get; set; }
        public string GuestPhoneNumber { get; set; }
        public string Currency { get; set; }
    }
}