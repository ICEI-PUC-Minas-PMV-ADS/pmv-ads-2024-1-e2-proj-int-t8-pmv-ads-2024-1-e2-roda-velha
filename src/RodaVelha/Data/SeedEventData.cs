using Microsoft.EntityFrameworkCore;
using RodaVelha.Models;

namespace RodaVelha.Data;

public static class SeedEventData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RodaVelhaContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RodaVelhaContext>>()))
        {
            // Look for any events.
            if (context.Events.Any())
            {
                return;   // DB has been seeded
            }

            context.Events.AddRange(
                new Events
                {
                    Name = "Encontro de Clássicos",
                    Description = "Exposição de carros clássicos com a presença de colecionadores e entusiastas.",
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(10).AddHours(5),
                    Location = "Praça dos Veteranos",
                    Organizer = "Clube dos Clássicos",
                    Likes = 6,
                    Photo = "/assets/images/events/event1.jpg",
                    Phone = "(31) 3000-4444",
                    UserId = 1,
                    User = context.Users.Find(1)
                },
                new Events
                {
                    Name = "Feira Tuning Urbana",
                    Description = "Venha conferir as mais recentes inovações em tuning e performance automotiva.",
                    StartDate = DateTime.Now.AddDays(20),
                    EndDate = DateTime.Now.AddDays(20).AddHours(5),
                    Location = "Estacionamento do Estádio Municipal",
                    Organizer = "Tuning Club",
                    Likes = 6,
                    Photo = "/assets/images/events/event2.jpg",
                    Phone = "(31) 3000-4444",
                    UserId = 2,
                    User = context.Users.Find(2)
                },
                new Events
                {
                    Name = "Rally Local",
                    Description = "Participe ou assista ao nosso rally local, aberto a todos os entusiastas do automobilismo.",
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(30).AddHours(8),
                    Location = "Circuito da Montanha",
                    Organizer = "Rally Club",
                    Likes = 6,
                    Photo = "/assets/images/events/event3.jpg",
                    Phone = "(31) 3000-4444",
                    UserId = 3,
                    User = context.Users.Find(3)
                },
                new Events
                {
                    Name = "Encontro de Supercarros",
                    Description = "Exibição dos supercarros mais rápidos do mundo, com oportunidade de test-drive para os participantes.",
                    StartDate = DateTime.Now.AddDays(40),
                    EndDate = DateTime.Now.AddDays(40).AddHours(4),
                    Location = "Autódromo Internacional",
                    Organizer = "Supercars Fan Club",
                    Likes = 6,
                    Photo = "/assets/images/events/event4.jpg",
                    Phone = "(31) 3000-4444",
                    UserId = 4,
                    User = context.Users.Find(4)
                },
                new Events
                {
                    Name = "Competição de Dragsters",
                    Description = "Desafie os limites de velocidade na nossa pista de arrancada com competições ao longo do dia.",
                    StartDate = DateTime.Now.AddDays(50),
                    EndDate = DateTime.Now.AddDays(50).AddHours(7),
                    Location = "Drag Race Arena",
                    Organizer = "Speedsters Club",
                    Likes = 6,
                    Photo = "/assets/images/events/event5.jpg",
                    Phone = "(31) 3000-4444",
                    UserId = 4,
                    User = context.Users.Find(4)
                }
            );

            context.SaveChanges();
        }
    }
}
