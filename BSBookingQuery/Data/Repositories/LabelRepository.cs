using BSBookingQuery.Data.Context;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.Data.Repositories
{
    public class LabelRepository : GenericRepository<Label>, ILabelRepository
    {
        public LabelRepository(BSBookingQueryDBContext context) : base(context)
        {
        }

        public async void test()
        {
            var data = await _context.Labels.ToListAsync();
        }
    }
}
