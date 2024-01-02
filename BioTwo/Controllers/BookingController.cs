using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BioTwo.Data;
using BioTwo.Models;

public class BookingController : Controller
{
    private readonly MovieContext _context;

    public BookingController(MovieContext context)
    {
        _context = context;
    }

    // GET: Booking/Confirmation
    public IActionResult Confirmation(string bookingNumber)
    {
        var booking = _context.Bookings
            .Include(b => b.Showing)
                .ThenInclude(s => s.Movie)
            .Include(b => b.Showing)
                .ThenInclude(s => s.Salon)
            .FirstOrDefault(b => b.BookingNr == bookingNumber);

        if (booking == null)
        {
            return View("BookingNotFoundView", bookingNumber);
        }

        return View(booking);
    }

    // GET: Booking/Search
    public IActionResult Search()
    {
        return View();
    }

    // POST: Booking/Search
    [HttpPost]
    public IActionResult Search(string bookingNumber)
    {
        if (string.IsNullOrEmpty(bookingNumber))
        {
            return View("BookingNotFoundView");
        }

        var booking = _context.Bookings
            .Include(b => b.Showing)
                .ThenInclude(s => s.Movie)
            .Include(b => b.Showing)
                .ThenInclude(s => s.Salon)
            .FirstOrDefault(b => b.BookingNr == bookingNumber);

        if (booking == null)
        {
            return View("BookingNotFoundView", bookingNumber);
        }

        return View("Confirmation", booking);
    }

    [HttpPost]
    public IActionResult Create(int showingId, List<int> selectedSeats, string customerName, string customerEmail)
    {
        
        if (selectedSeats == null || !selectedSeats.Any() || string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerEmail))
        {
            return BadRequest("Invalid inputs");
        }

        // Availability of seats
        foreach (var seatNumber in selectedSeats)
        {
            if (!IsSeatAvailable(showingId, seatNumber))
            {
                return BadRequest($"Seat {seatNumber} is no longer available");
            }
        }

        
        var bookingNumber = GenerateRandomBookingNumber();

        // Booking entities
        foreach (var seatNumber in selectedSeats)
        {
            var showing = _context.Showings.Include(s => s.Movie).FirstOrDefault(s => s.ShowingID == showingId);

            var booking = new Booking
            {
                BookingNr = bookingNumber,
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                ShowingID = showingId,
                SeatNumber = seatNumber,
                Showing = showing
            };

            _context.Bookings.Add(booking);

            
            MarkSeatAsBooked(showingId, seatNumber);
        }

        _context.SaveChanges();

        return RedirectToAction("Confirmation", new { bookingNumber });
    }

    private string GenerateRandomBookingNumber()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 8);
    }

    private bool IsSeatAvailable(int showingId, int seatNumber)
    {
        var isBooked = _context.Bookings
            .Any(b => b.ShowingID == showingId && b.SeatNumber == seatNumber);

        return !isBooked;
    }

    private void MarkSeatAsBooked(int showingId, int seatNumber)
    {
        var showing = _context.Showings.Find(showingId);
        if (showing != null)
        {
            _context.SaveChanges();
        }
    }
}
