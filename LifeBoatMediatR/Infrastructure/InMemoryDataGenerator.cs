using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LifeBoatMediatR.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBoatMediatR.Infrastructure
{
    public class InMemoryDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var contextOptions = serviceProvider.GetRequiredService<DbContextOptions<LifeBoatMediatRDbContext>>();

            using (var dbContext = new LifeBoatMediatRDbContext(contextOptions))
            {
                SeedData(dbContext);
            }
        }

        public static void Initialize(LifeBoatMediatRDbContext dbContext)
        {
            SeedData(dbContext);
        }

        static void SeedData(LifeBoatMediatRDbContext dbContext)
        {
            if (dbContext.User.Any())
            {
                return;
            }

            var random = new Random();

            dbContext.User.AddRange(
                new User(random.Next(), "Test1", "test1@email.com", DateTime.Now.AddDays(-15)),
                new User(random.Next(), "Test2", "test2@email.com", DateTime.Now.AddDays(-20)),
                new User(random.Next(), "Test3", "test3@email.com", DateTime.Now.AddDays(-25)),
                new User(random.Next(), "Test4", "test4@email.com", DateTime.Now.AddDays(-30))
            );

            dbContext.SaveChanges();
        }
    }
}
