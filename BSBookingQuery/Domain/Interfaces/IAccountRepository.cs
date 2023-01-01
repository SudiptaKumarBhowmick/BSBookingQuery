using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;

namespace BSBookingQuery.Domain.Interfaces
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        Task<UserDto> LogIn(LogInDto logInDto);
        Task<UserDto> Register(RegisterDto registerDto);
        IEnumerable<UserTypeDto> GetAllUserTypes();
    }
}
