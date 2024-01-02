using BioTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BioTwo.Data
{
    public class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return; // DB SEEDED
            }

            var movies = new Movie[]
            {
                new Movie {Title = "DIE HARD", Genre = "ACTION", Length = 150, Price = 99, Description = "Bruce Willis Dies." },
                new Movie {Title = "DIE HARD 2", Genre = "ACTION", Length = 159, Price = 100, Description = "Bruce Willis Dies Harder." },
                new Movie {Title = "A GOOD DAY TO DIE HARD", Genre = "ACTION", Length = 160, Price = 102, Description = "Bruce Willis Dies the Hardest." },
                new Movie {Title = "Die Hard With A Vengeance", Genre = "ACTION", Length = 160, Price = 102, Description = "Bruce Willis dies with a vengeance" },
                new Movie {Title = "DIE HARD 5", Genre = "ACTION", Length = 160, Price = 102, Description = "Bruce Willis Dies the Hardest." }
            };
            context.Movies.AddRange(movies);
            context.SaveChanges();

            var salon = new Salon[]
            {
                new Salon { Name = "Salon One", SeatCount = 40, SeatPerRow = 10},
                new Salon { Name = "Salon Two", SeatCount = 70, SeatPerRow = 14}
            };
            context.Salons.AddRange(salon);
            context.SaveChanges();

            var showings = new List<Showing>
            {
                new Showing { ShowingTime = DateTime.Now.AddDays(1), SalonID = 1, MovieID = 1 },
                new Showing { ShowingTime = DateTime.Now.AddDays(2), SalonID = 2, MovieID = 2 },
                new Showing { ShowingTime = DateTime.Now.AddDays(3), SalonID = 1, MovieID = 3 },
                new Showing { ShowingTime = DateTime.Now.AddDays(4), SalonID = 2, MovieID = 5 },
                new Showing { ShowingTime = DateTime.Now.AddDays(5), SalonID = 1, MovieID = 4 }
            };
            context.Showings.AddRange(showings);
            context.SaveChanges();

            var bookings = new List<Booking>
            {
                new Booking { BookingNr = "B001", CustomerName = "John Doe", CustomerEmail = "john@example.com", ShowingID = 1 },
                new Booking { BookingNr = "B002", CustomerName = "Jane Doe", CustomerEmail = "jane@example.com", ShowingID = 2 }
            };
            context.Bookings.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
