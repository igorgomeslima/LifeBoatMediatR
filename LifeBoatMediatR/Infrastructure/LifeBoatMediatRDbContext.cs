using LifeBoatMediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeBoatMediatR.Infrastructure
{
    public class LifeBoatMediatRDbContext : DbContext
    {
        public LifeBoatMediatRDbContext(DbContextOptions<LifeBoatMediatRDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
