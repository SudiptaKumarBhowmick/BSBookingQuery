using BSBookingQuery.Data.Context;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.Data.Repositories
{
    public class CommentRepository : GenericRepository<CommentHistory>, ICommentRepository
    {
        public CommentRepository(BSBookingQueryDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CommentHistory>> GetAllComments()
        {
            var comments = await _context.CommentHistories
                   .Include(user => user.User)
                   .Include(hotel => hotel.Hotel)
                   .ToListAsync();
            return comments;
        }
    }
}
