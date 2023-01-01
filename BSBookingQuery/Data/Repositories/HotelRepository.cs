using BSBookingQuery.Data.Context;
using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BSBookingQuery.Data.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(BSBookingQueryDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            var hotels = await _context.Hotels
                   .Include(label => label.Label)
                   .ToListAsync();
            return hotels;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsBySearchParam(SearchParamDto searchParam)
        {
            var hotels = await _context.Hotels
                   .Include(label => label.Label)
                   .ToListAsync();

            if (!string.IsNullOrEmpty(searchParam.name))
            {
                hotels = hotels.Where(h => searchParam.name.Contains(h.HotelId)
                        || searchParam.name.ToLower().Contains(h.Name.ToLower())
                        || searchParam.name.ToLower().Contains(h.Label.Location.ToLower())).ToList();
            }
            else if (searchParam.lowerRatings != 0 && searchParam.upperRatings != 0)
            {
                hotels = hotels.Where(h => h.Ratings >= searchParam.lowerRatings && h.Ratings <= searchParam.upperRatings).ToList();
            }

            return hotels;
        }

    }
}
