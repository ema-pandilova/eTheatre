using eTheatre.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTheatre.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_play>().HasKey(ap => new
            {
                ap.ActorId,
                ap.PlayId
            });

            modelBuilder.Entity<Actor_play>().HasOne(p => p.Play).WithMany(ap => ap.Actors_Plays).HasForeignKey(p => p.PlayId);
            modelBuilder.Entity<Actor_play>().HasOne(p => p.Actor).WithMany(ap => ap.Actors_Plays).HasForeignKey(p => p.ActorId);


            base.OnModelCreating(modelBuilder);


        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Actor_play> Actors_Plays { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
