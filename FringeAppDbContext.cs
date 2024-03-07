using Fringes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fringes
{
    public class FringeAppDbContext : IdentityDbContext<User>
    {
        public FringeAppDbContext(DbContextOptions<FringeAppDbContext> options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>().HasKey(e => e.Id);
        }
    }
}
