namespace BSBookingQuery.Domain.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public int UserTypeId { get; set; }
    }
}
