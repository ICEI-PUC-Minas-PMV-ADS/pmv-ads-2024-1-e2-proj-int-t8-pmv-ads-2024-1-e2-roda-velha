using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RodaVelha.Data;
using RodaVelha.Models;
using RodaVelha.ViewModels;
using System.Diagnostics;

namespace RodaVelha.Controllers
{
    public class HomeController : Controller
    {

        private readonly RodaVelhaContext _context;

        public HomeController(RodaVelhaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            var events = await _context.Events.ToListAsync();
            var viewModel = new HomePageViewModel
            {
                users = users,
                events = events
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
