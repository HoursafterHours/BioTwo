using System;

namespace BioTwo.Models
{
    public class Showing
    {
        public int ShowingID { get; set; }
        public int MovieID { get; set; }
        public int SalonID { get; set; }
        public DateTimeOffset ShowingTime { get; set; }

        public Salon Salon { get; set; }
        public Movie Movie { get; set; }

    }
}
