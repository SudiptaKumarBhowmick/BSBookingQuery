using BSBookingQuery.Domain.Entities;

namespace BSBookingQuery.Domain.DTOs
{
    public class CommentDto
    {
        public string Comment { get; set; } = "";
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        public int? HotelId { get; set; }
    }
}
