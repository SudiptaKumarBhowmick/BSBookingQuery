using BSBookingQuery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.Data.Context
{
    public class BSBookingQueryDBContext : DbContext
    {
        public BSBookingQueryDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommentHistory> CommentHistories { get; set; }
    }
}
