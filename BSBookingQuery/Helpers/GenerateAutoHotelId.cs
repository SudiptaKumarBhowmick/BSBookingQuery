namespace BSBookingQuery.Helpers
{
    public static class GenerateAutoHotelId
    {
        public static string GenerateHotelId(string name)
        {
            Guid id = Guid.NewGuid();
            return name + "-" + id.ToString();
        }
    }
}
