using cinemawebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Data
{
    public static class HallSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>().HasData(
                new Hall { Id = 1, Name = "Hall 1", Capacity = 120, CinemaId = 1 },
                new Hall { Id = 2, Name = "IMAX", Capacity = 200, CinemaId = 1 },
                new Hall { Id = 3, Name = "Hall 1", Capacity = 100, CinemaId = 2 },
                new Hall { Id = 4, Name = "Hall 2", Capacity = 80, CinemaId = 2 },
                new Hall { Id = 5, Name = "Hall 1", Capacity = 150, CinemaId = 3 },
                new Hall { Id = 6, Name = "Hall 1", Capacity = 130, CinemaId = 4 }
            );
        }
    }
}