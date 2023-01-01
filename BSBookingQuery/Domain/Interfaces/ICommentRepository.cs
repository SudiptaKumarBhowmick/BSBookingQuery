using BSBookingQuery.Domain.Entities;

namespace BSBookingQuery.Domain.Interfaces
{
    public interface ICommentRepository : IGenericRepository<CommentHistory>
    {
        Task<IEnumerable<CommentHistory>> GetAllComments();
    }
}
