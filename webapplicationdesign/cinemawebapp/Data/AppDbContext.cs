using cinemawebapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace cinemawebapp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relații explicite
            modelBuilder.Entity<Hall>()
                .HasOne(h => h.Cinema)
                .WithMany(c => c.Halls)
                .HasForeignKey(h => h.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Screening>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Screenings)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Screening>()
                .HasOne(s => s.Hall)
                .WithMany(h => h.Screenings)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Restrict); // evitam cascade conflict

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Screening)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.ScreeningId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Promotion>()
                .Property(p => p.DiscountPercent)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Ticket>()
    .HasOne(t => t.User)
    .WithMany()
    .HasForeignKey(t => t.UserId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TicketType>()
    .Property(t => t.Price)
    .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<TicketType>().HasData(
                new TicketType { Id = 1, Name = "Standard", Price = 25, MinSeats = 1, MaxSeats = 5, IsActive = true },
                new TicketType { Id = 2, Name = "Student", Price = 18, MinSeats = 1, MaxSeats = 5, IsActive = true },
                new TicketType { Id = 3, Name = "Senior", Price = 20, MinSeats = 1, MaxSeats = 5, IsActive = true },
                new TicketType { Id = 4, Name = "Couples Friday", Price = 55, MinSeats = 2, MaxSeats = 2, DayRestriction = "Friday", Emoji = "💑", IsActive = true },
                new TicketType { Id = 5, Name = "Family Pack", Price = 99, MinSeats = 4, MaxSeats = 4, Emoji = "👨‍👩‍👧‍👦", IsActive = true },
                new TicketType { Id = 6, Name = "Wednesday 1+1", Price = 25, MinSeats = 2, MaxSeats = 2, DayRestriction = "Wednesday", Emoji = "🎟️", IsActive = true }
            );

            // Seed
            CinemaSeed.Seed(modelBuilder);
            MovieSeed.Seed(modelBuilder);
            HallSeed.Seed(modelBuilder);
            ScreeningSeed.Seed(modelBuilder);
            TicketSeed.Seed(modelBuilder);
            PromotionSeed.Seed(modelBuilder);
        }
    }
}