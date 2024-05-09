using Microsoft.EntityFrameworkCore;
using RodaVelha.Models;

namespace RodaVelha.Data;

public static class SeedLikeData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RodaVelhaContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RodaVelhaContext>>()))
        {
            // Look for any likes.
            if (context.Likes.Any())
            {
                return;   // DB has been seeded
            }

            // Fetch all events and users from the database
            var events = context.Events.ToList();
            var users = context.Users.ToList();

            // Create likes for each combination of event and user
            List<Like> likes = new List<Like>();
            foreach (var user in users)
            {
                foreach (var evnt in events)
                {
                    likes.Add(new Like { Event = evnt, EventId = evnt.Id, User = user, UserId = user.ID });
                }
            }

            // Add likes to the database context and save changes
            context.Likes.AddRange(likes);
            context.SaveChanges();
        }
    }
}
