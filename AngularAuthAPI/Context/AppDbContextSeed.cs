using AngularAuthAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAuthAPI.Context
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILogger<AppDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(GetPreconfiguredOrders());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(AppDbContext).Name);

            }
        }


        private static IEnumerable<User> GetPreconfiguredOrders()
        {
            return new List<User>
            {
                new User() {UserName = "Phani1269", FirstName = "Phani", LastName = "Kumar", Email = "phanikumar827@gmail.com", Password="admin" }
            };
        }
    }
}
