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
           var userEvents = await ( from user in _context.Users
                                    join evt in _context.Events on user.ID equals evt.UserId
                                     select new HomePageViewModel
                                     {
                                         User = user,
                                         Event = evt
                                     }).ToListAsync();

            return View(userEvents);
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
