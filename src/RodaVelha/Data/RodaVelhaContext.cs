using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RodaVelha.Models;

namespace RodaVelha.Data
{
    public class RodaVelhaContext : DbContext
    {
        public RodaVelhaContext (DbContextOptions<RodaVelhaContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Events> Events { get; set; } = default!;
        public DbSet<Like> Likes { get; set; } = default!;
    }
}
