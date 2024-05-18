using Microsoft.EntityFrameworkCore;
using RodaVelha.Models;

namespace RodaVelha.Data;

public static class SeedUserData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RodaVelhaContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RodaVelhaContext>>()))
        {
            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Users.AddRange(
                new User
                {
                    Name = "Víctor Santana Ballestrini de Oliveira",
                    Email = "vsballestrini@gmail.com",
                    Password = "$2a$11$PyEKiCKHflvSDR7iwxxu/.Y1xqbbrKK7ZQn1ZKnytmNGPODBUzSkm",
                    Photo = "https://gravatar.com/avatar/98caf10cc9a7d8a588d1744fed950a5c?s=400&d=robohash&r=x"
                },
                new User
                {
                    Name = "Gabriela Aparecida de Araújo",
                    Email = "gabriela.apdearaujo@gmail.com",
                    Password = "$2a$11$PyEKiCKHflvSDR7iwxxu/.Y1xqbbrKK7ZQn1ZKnytmNGPODBUzSkm",
                    Photo = "https://gravatar.com/avatar/b286cf4679ae4d5a0816e3d601eb197b?s=400&d=robohash&r=x"
                },
                new User
                {
                    Name = "Átila Eduardo de Pádua Ribeiro",
                    Email = "atilaedu1@gmail.com",
                    Password = "$2a$11$PyEKiCKHflvSDR7iwxxu/.Y1xqbbrKK7ZQn1ZKnytmNGPODBUzSkm",
                    Photo = "https://gravatar.com/avatar/9485fd89aeec083e133b7a369f718c05?s=400&d=robohash&r=x"
                },
                new User
                {
                    Name = "Aleksander Cunha Garcia Romero",
                    Email = "aleksandercgr@gmail.com",
                    Password = "$2a$11$PyEKiCKHflvSDR7iwxxu/.Y1xqbbrKK7ZQn1ZKnytmNGPODBUzSkm",
                    Photo = "https://gravatar.com/avatar/a6f80486880fa9d42c3e6d373ed4fa1f?s=400&d=robohash&r=x"
                },
                new User
                {
                    Name = "Anderson da Silva Gomes",
                    Email = "dimdinho@gmail.com",
                    Password = "$2a$11$PyEKiCKHflvSDR7iwxxu/.Y1xqbbrKK7ZQn1ZKnytmNGPODBUzSkm",
                    Photo = "https://gravatar.com/avatar/0b5171bf5c4d579d212571859d81f7dd?s=400&d=robohash&r=x"
                },
                new User
                {
                    Name = "Arthur de Andrade Simões",
                    Email = "arthursimoes155@gmail.com",
                    Password = "$2a$11$PyEKiCKHflvSDR7iwxxu/.Y1xqbbrKK7ZQn1ZKnytmNGPODBUzSkm",
                    Photo = "https://gravatar.com/avatar/40b0de3822dff4d077f3b909b1374f1c?s=400&d=robohash&r=x"
                }
            );
            context.SaveChanges();
        }
    }
}