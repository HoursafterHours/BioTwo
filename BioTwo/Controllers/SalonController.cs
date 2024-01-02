using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BioTwo.Data;
using System.Drawing.Text;

public class SalonController : Controller
{
    private readonly MovieContext _context;

    public SalonController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
       
        var salons = _context.Salons.ToList();

       
        return View(salons);
    }
}