using cinemawebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Data
{
    public static class TicketSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, ScreeningId = 1, SeatNumber = "A1", TicketType = "Standard", Price = 35m, PurchasedAt = new DateTime(2025, 5, 9, 10, 0, 0) },
                new Ticket { Id = 2, ScreeningId = 1, SeatNumber = "A2", TicketType = "Student", Price = 28m, PurchasedAt = new DateTime(2025, 5, 9, 10, 5, 0) },
                new Ticket { Id = 3, ScreeningId = 2, SeatNumber = "B5", TicketType = "Senior", Price = 25m, PurchasedAt = new DateTime(2025, 5, 9, 11, 0, 0) },
                new Ticket { Id = 4, ScreeningId = 3, SeatNumber = "C3", TicketType = "Standard", Price = 35m, PurchasedAt = new DateTime(2025, 5, 10, 9, 0, 0) },
                new Ticket { Id = 5, ScreeningId = 4, SeatNumber = "D7", TicketType = "Standard", Price = 35m, PurchasedAt = new DateTime(2025, 5, 10, 12, 0, 0) }
            );
        }
    }
}