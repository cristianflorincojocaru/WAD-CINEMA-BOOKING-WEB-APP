using cinemawebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Data
{
    public static class ScreeningSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Screening>().HasData(
                // MON 20 Apr
                new Screening { Id = 1, MovieId = 1, HallId = 1, StartTime = new DateTime(2026, 4, 20, 18, 0, 0) },
                new Screening { Id = 2, MovieId = 2, HallId = 2, StartTime = new DateTime(2026, 4, 20, 21, 0, 0) },
                // TUE 21 Apr
                new Screening { Id = 3, MovieId = 3, HallId = 3, StartTime = new DateTime(2026, 4, 21, 17, 30, 0) },
                new Screening { Id = 4, MovieId = 1, HallId = 4, StartTime = new DateTime(2026, 4, 21, 20, 0, 0) },
                // WED 22 Apr
                new Screening { Id = 5, MovieId = 2, HallId = 5, StartTime = new DateTime(2026, 4, 22, 19, 0, 0) },
                new Screening { Id = 6, MovieId = 3, HallId = 6, StartTime = new DateTime(2026, 4, 22, 21, 30, 0) },
                // THU 23 Apr
                new Screening { Id = 7, MovieId = 1, HallId = 2, StartTime = new DateTime(2026, 4, 23, 18, 0, 0) },
                new Screening { Id = 8, MovieId = 2, HallId = 3, StartTime = new DateTime(2026, 4, 23, 20, 30, 0) },
                // FRI 24 Apr
                new Screening { Id = 9, MovieId = 3, HallId = 1, StartTime = new DateTime(2026, 4, 24, 17, 0, 0) },
                new Screening { Id = 10, MovieId = 1, HallId = 5, StartTime = new DateTime(2026, 4, 24, 20, 0, 0) },
                // SAT 25 Apr
                new Screening { Id = 11, MovieId = 2, HallId = 4, StartTime = new DateTime(2026, 4, 25, 15, 0, 0) },
                new Screening { Id = 12, MovieId = 3, HallId = 6, StartTime = new DateTime(2026, 4, 25, 19, 30, 0) },
                // SUN 27 Apr
                new Screening { Id = 13, MovieId = 1, HallId = 3, StartTime = new DateTime(2026, 4, 26, 14, 0, 0) },
                new Screening { Id = 14, MovieId = 2, HallId = 1, StartTime = new DateTime(2026, 4, 26, 18, 0, 0) }
            );
        }
    }
}