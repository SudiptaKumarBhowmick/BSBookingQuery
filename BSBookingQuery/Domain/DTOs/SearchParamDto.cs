namespace BSBookingQuery.Domain.DTOs
{
    public class SearchParamDto
    {
        public string name { get; set; } = "";
        public decimal lowerRatings { get; set; } = 0;
        public decimal upperRatings { get; set; } = 0;
    }
}
