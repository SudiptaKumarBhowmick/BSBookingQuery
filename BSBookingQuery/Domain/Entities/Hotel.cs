namespace BSBookingQuery.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelId { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal Ratings { get; set; }
        public int LabelId { get; set; }
        public Label Label { get; set; }
        public ICollection<CommentHistory> CommentHistories { get; set; }
    }
}
