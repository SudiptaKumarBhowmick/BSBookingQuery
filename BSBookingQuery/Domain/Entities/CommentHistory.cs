namespace BSBookingQuery.Domain.Entities
{
    public class CommentHistory
    {
        public int Id { get; set; }
        public string Comment { get; set; } = "";
        public DateTime CommentDate { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
