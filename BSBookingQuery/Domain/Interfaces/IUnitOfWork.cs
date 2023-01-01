namespace BSBookingQuery.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository Hotels { get; }
        ILabelRepository Labels { get; }
        ICommentRepository Comments { get; }
        IAccountRepository Accounts { get; }
        int Complete();
    }
}
