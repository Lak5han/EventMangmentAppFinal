using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class EventmanagementDbContext : DbContext
    {
        public DbSet<EventRound> EventRounds { get; set; }
        public DbSet<Collage> Collages { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<EventRegistration> EventEventRegistrations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
