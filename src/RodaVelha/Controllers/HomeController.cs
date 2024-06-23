using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

       /* public async Task<IActionResult> Index()
        {
            ViewBag.States = GetBrazilianStates();
            var userEvents = await ( from user in _context.Users
                                    join evt in _context.Events on user.ID equals evt.UserId
                                     select new HomePageViewModel
                                     {
                                         User = user,
                                         Event = evt
                                     }).ToListAsync();

            return View(userEvents);
        }*/
        public async Task<IActionResult> Index(string state)
        {
            ViewBag.States = GetBrazilianStates();

           var userEvents = await ( from user in _context.Users
                                    join evt in _context.Events on user.ID equals evt.UserId
                                     select new HomePageViewModel
                                     {
                                         User = user,
                                         Event = evt
                                     }).ToListAsync();

            if (!String.IsNullOrEmpty(state))
            {
                var events = userEvents.Where(e => e.Event.State == state); 
                return View(events);
            }

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
        private List<SelectListItem> GetBrazilianStates()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "AC", Text = "Acre" },
            new SelectListItem { Value = "AL", Text = "Alagoas" },
            new SelectListItem { Value = "AP", Text = "Amapa" },
            new SelectListItem { Value = "AM", Text = "Amazonas" },
            new SelectListItem { Value = "BA", Text = "Bahia" },
            new SelectListItem { Value = "CE", Text = "Ceara" },
            new SelectListItem { Value = "DF", Text = "Distrito Federal" },
            new SelectListItem { Value = "ES", Text = "Espirito Santo" },
            new SelectListItem { Value = "GO", Text = "Goias" },
            new SelectListItem { Value = "MA", Text = "Maranhao" },
            new SelectListItem { Value = "MT", Text = "Mato Grosso" },
            new SelectListItem { Value = "MS", Text = "Mato Grosso do Sul" },
            new SelectListItem { Value = "MG", Text = "Minas Gerais" },
            new SelectListItem { Value = "PA", Text = "Para" },
            new SelectListItem { Value = "PB", Text = "Paraiba" },
            new SelectListItem { Value = "PR", Text = "Parana" },
            new SelectListItem { Value = "PE", Text = "Pernambuco" },
            new SelectListItem { Value = "PI", Text = "Piaui" },
            new SelectListItem { Value = "RJ", Text = "Rio de Janeiro" },
            new SelectListItem { Value = "RN", Text = "Rio Grande do Norte" },
            new SelectListItem { Value = "RS", Text = "Rio Grande do Sul" },
            new SelectListItem { Value = "RO", Text = "Rondonia" },
            new SelectListItem { Value = "RR", Text = "Roraima" },
            new SelectListItem { Value = "SC", Text = "Santa Catarina" },
            new SelectListItem { Value = "SP", Text = "Sao Paulo" },
            new SelectListItem { Value = "SE", Text = "Sergipe" },
            new SelectListItem { Value = "TO", Text = "Tocantins" }
        };
        }
    }
}
