using BSBookingQuery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.Data.Repositories
{
    public static class InjectServices
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<ILabelRepository, LabelRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
