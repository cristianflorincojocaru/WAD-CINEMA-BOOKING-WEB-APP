using cinemawebapp.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace cinemawebapp.Data
{
    public static class CinemaSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema
                {
                    Id = 1,
                    Name = "The Film Vault AFI Palace Cotroceni",
                    City = "Bucharest",
                    Address = "General Paul Teodorescu Boulevard no. 4, AFI Palace Cotroceni",
                    OpeningHours = "Mon - Sun 10:00 - 23:00",
                    Contact = "officeafibuc@thefilmvault.ro",
                    ImagePath = "/images/cinema1.jpg"
                },
                new Cinema
                {
                    Id = 2,
                    Name = "The Film Vault Promenada Mall Craiova",
                    City = "Craiova",
                    Address = "Severin Street 61, Promenada Mall",
                    OpeningHours = "Mon - Sun 10:30 - 23:00",
                    Contact = "officepromenadacraiova@thefilmvault.ro",
                    ImagePath = "/images/cinema2.jpg"
                },
                new Cinema
                {
                    Id = 3,
                    Name = "The Film Vault Cinema City Cluj-Napoca",
                    City = "Cluj-Napoca",
                    Address = "Alexandru Vaida Voevod Street 55, Iulius Mall",
                    OpeningHours = "Mon - Sun 10:30 - 23:00",
                    Contact = "officecincluj@thefilmvault.ro",
                    ImagePath = "/images/cinema3.jpg"
                },
                new Cinema
                {
                    Id = 4,
                    Name = "The Film Vault Cinema City Timisoara",
                    City = "Timisoara",
                    Address = "100 Sagului Street, Shopping City Timisoara",
                    OpeningHours = "Mon - Sun 10:00 - 23:00",
                    Contact = "officecintim@thefilmvault.ro",
                    ImagePath = "/images/cinema4.jpg"
                }
            );
        }
    }
}
