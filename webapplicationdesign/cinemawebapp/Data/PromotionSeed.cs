using cinemawebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Data
{
    public static class PromotionSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>().HasData(
                new Promotion
                {
                    Id = 1,
                    Title = "Student Discount",
                    Description = "20% off with a valid student ID. Available for all screenings, every day. Just select the Student ticket type when booking.",
                    Emoji = "🎓",
                    DiscountPercent = 20m,
                    ValidFrom = new DateTime(2026, 1, 1),
                    ValidUntil = new DateTime(2026, 12, 31),
                    IsActive = true
                },
                new Promotion
                {
                    Id = 2,
                    Title = "Veterans Monday",
                    Description = "Free admission every Monday for veterans and senior citizens aged 65+. Present your ID at the box office.",
                    Emoji = "🎖️",
                    DiscountPercent = 100m,
                    ValidFrom = new DateTime(2026, 1, 1),
                    ValidUntil = new DateTime(2026, 12, 31),
                    IsActive = true
                },
                new Promotion
                {
                    Id = 3,
                    Title = "Wednesday 1+1",
                    Description = "Buy one ticket every Wednesday and get a second one free. Valid for any screening on Wednesdays only.",
                    Emoji = "🎬",
                    DiscountPercent = 50m,
                    ValidFrom = new DateTime(2026, 1, 1),
                    ValidUntil = new DateTime(2026, 12, 31),
                    IsActive = true
                },
                new Promotion
                {
                    Id = 4,
                    Title = "Couples Friday",
                    Description = "Two tickets for just 55 RON every Friday. Select the Couples Friday option when booking — only available on Fridays.",
                    Emoji = "💑",
                    DiscountPercent = 0m,
                    ValidFrom = new DateTime(2026, 1, 1),
                    ValidUntil = new DateTime(2026, 12, 31),
                    IsActive = true
                },
                new Promotion
                {
                    Id = 5,
                    Title = "Family Pack",
                    Description = "Four tickets for 99 RON — perfect for a family night out. Select the Family Pack option when booking.",
                    Emoji = "👨‍👩‍👧‍👦",
                    DiscountPercent = 0m,
                    ValidFrom = new DateTime(2026, 1, 1),
                    ValidUntil = new DateTime(2026, 12, 31),
                    IsActive = true
                }
            );
        }
    }
}