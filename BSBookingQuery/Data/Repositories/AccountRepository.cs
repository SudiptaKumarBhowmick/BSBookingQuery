using AutoMapper;
using BSBookingQuery.Data.Context;
using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Enum;
using BSBookingQuery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.Data.Repositories
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        private readonly IMapper _mapper;
        public AccountRepository(BSBookingQueryDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<UserDto> LogIn(LogInDto logInDto)
        {
            var loginUserInfo = await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(logInDto.Email) && user.Password.Equals(logInDto.Password));

            if (loginUserInfo != null)
            {
                var dataToReturn = _mapper.Map<UserDto>(loginUserInfo);

                var userTypeList = GetAllUserTypes();
                foreach (var type in userTypeList)
                {
                    if (type.UserTypeId == loginUserInfo.UserTypeId)
                    {
                        dataToReturn.UserTypeName = type.UserTypeName;
                    }
                }

                return dataToReturn;
            }

            return null;
        }

        public IEnumerable<UserTypeDto> GetAllUserTypes()
        {
            var typeList = Enum.GetValues(typeof(UserTypes))
              .Cast<UserTypes>()
              .Select(t => new UserTypeDto
              {
                  UserTypeId = ((int)t),
                  UserTypeName = t.ToString()
              });
            return typeList.ToList();
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var userInfo = await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(registerDto.Email));
            if (userInfo != null)
            {
                return null;
            }

            User entity = _mapper.Map<User>(registerDto);

            if (entity != null)
            {
                await _context.Users.AddAsync(entity);

                var dataToReturn = _mapper.Map<UserDto>(registerDto);
                var userTypeList = GetAllUserTypes();
                foreach (var type in userTypeList)
                {
                    if (type.UserTypeId == registerDto.UserTypeId)
                    {
                        dataToReturn.UserTypeName = type.UserTypeName;
                    }
                }

                return dataToReturn;
            }

            return null;
        }

    }
}
