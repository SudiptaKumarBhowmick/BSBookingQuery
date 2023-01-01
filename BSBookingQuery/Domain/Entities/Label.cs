namespace BSBookingQuery.Domain.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public string Location { get; set; } = "";
        public ICollection<Hotel> Hotels { get; set; }
    }
}
