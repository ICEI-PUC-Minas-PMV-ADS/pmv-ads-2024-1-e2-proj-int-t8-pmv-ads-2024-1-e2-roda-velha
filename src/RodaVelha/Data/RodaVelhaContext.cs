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

        public DbSet<RodaVelha.Models.User> User { get; set; } = default!;
        public DbSet<RodaVelha.Models.Event> Event { get; set; } = default!;
    }
}
