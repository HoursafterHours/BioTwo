using BioTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BioTwo.Data;

public class HomeController : Controller
{
    private readonly MovieContext _context;

    public HomeController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        
        return View();
    }

    [HttpGet]
    public IActionResult Search(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            
            return RedirectToAction("Index");
        }

        var searchResults = _context.Movies
            .Where(m => m.Title.Contains(query))
            .ToList();

        ViewData["SearchResults"] = searchResults;
        ViewData["Query"] = query;

        return View();
    }
}