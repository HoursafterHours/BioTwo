using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BioTwo.Data;
using BioTwo.Models;
using BioTwo.ViewModel;

public class ShowingController : Controller
{
    private readonly MovieContext _context;

    public ShowingController(MovieContext context)
    {
        _context = context;
    }

    // GET: Showing
    public IActionResult Index()
    {
        var showings = _context.Showings
            .Include(s => s.Movie)
            .Include(s => s.Salon)
            .ToList();

        return View(showings);
    }

    public IActionResult SelectSeat(int id)
    {
        var showing = _context.Showings
            .Include(s => s.Movie)
            .Include(s => s.Salon)
            .FirstOrDefault(s => s.ShowingID == id);

        if (showing == null)
        {
            return NotFound();
        }

        
        var salonId = showing.SalonID;

       
        var availableSeats = Enumerable.Range(1, showing.Salon.SeatCount)
            .Where(seatNumber => IsSeatAvailable(showing, seatNumber))
            .ToList();

       
        var viewModel = new SelectSeatViewModel
        {
            Showing = showing,
            AvailableSeats = availableSeats
        };

       
        return View(viewModel);
    }

    private bool IsSeatAvailable(Showing showing, int seatNumber)
    {
       
        var isBooked = _context.Bookings
            .Any(b => b.ShowingID == showing.ShowingID && b.SeatNumber == seatNumber);

        
        return !isBooked;
    }
}
