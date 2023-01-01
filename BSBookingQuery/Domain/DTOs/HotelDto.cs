namespace BSBookingQuery.Domain.DTOs
{
    public class HotelDto
    {
        public string HotelId { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal Ratings { get; set; }
        public int LabelId { get; set; }
        public string Location { get; set; } = "";
    }
}
