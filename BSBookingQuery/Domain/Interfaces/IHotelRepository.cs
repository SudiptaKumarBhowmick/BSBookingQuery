using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;

namespace BSBookingQuery.Domain.Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<IEnumerable<Hotel>> GetHotelsBySearchParam(SearchParamDto searchParam);
    }
}
