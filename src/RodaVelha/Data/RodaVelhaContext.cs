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

        public DbSet<RodaVelha.Models.User> Users { get; set; } = default!;
        public DbSet<RodaVelha.Models.Event> Events { get; set; } = default!;
        public DbSet<RodaVelha.Models.Like> Likes { get; set; } = default!;
    }
}
