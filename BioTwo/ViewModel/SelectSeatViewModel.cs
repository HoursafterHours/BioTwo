using BioTwo.Models;

namespace BioTwo.ViewModel
{
    public class SelectSeatViewModel
    {
        public Showing Showing { get; set; }
        public List<int> AvailableSeats { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}