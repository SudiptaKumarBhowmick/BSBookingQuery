using BSBookingQuery.Data.Context;
using BSBookingQuery.Domain.Interfaces;

namespace BSBookingQuery.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BSBookingQueryDBContext _context;
        public IHotelRepository Hotels { get; }
        public ILabelRepository Labels { get; }
        public ICommentRepository Comments { get; }
        public IAccountRepository Accounts { get; }

        public UnitOfWork(BSBookingQueryDBContext bookingQueryDBContext,
            IHotelRepository hotelRepository,
            ILabelRepository labelRepository,
            ICommentRepository commentRepository,
            IAccountRepository accountRepository)
        {
            this._context = bookingQueryDBContext;

            this.Hotels = hotelRepository;
            this.Labels = labelRepository;
            this.Comments = commentRepository;
            this.Accounts = accountRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
