namespace BioTwo.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string BookingNr { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int ShowingID { get; set; }

        
        public int SeatNumber { get; set; }

        public Showing Showing { get; set; }
    }
}