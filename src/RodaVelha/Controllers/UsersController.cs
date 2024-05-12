using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RodaVelha.Data;
using RodaVelha.Models;
using RodaVelha.ViewModels;

namespace RodaVelha.Controllers
{
    public class UsersController : Controller
    {
        private readonly RodaVelhaContext _context;

        public UsersController(RodaVelhaContext context)
        {
            _context = context;
        }

        // GET: Users
         public async Task<IActionResult> Index()
         {
             var usuarioLogadoId = obterUsuarioLogadoId();
             if(usuarioLogadoId == null)
                 return NotFound();

             
             var events = _context.Events.Where( p => p.Id == usuarioLogadoId).ToList(); 
            
             var user = _context.Users.FirstOrDefault(u => u.ID == usuarioLogadoId);

            var query = from eventos in _context.Events
                        join like in _context.Likes on eventos.Id equals like.EventId
                        where like.UserId == usuarioLogadoId
                        select eventos;


            var eventlist = query.ToList();

            var viewModel = new UserPageViewModel
            {
                events = events,
                user = user!,
                eventsLike = eventlist,
            };


            return View(viewModel);


         }
         public int obterUsuarioLogadoId()
         {
             return 1; //Valor temporario
         }

         public IActionResult Login()
         {
          return View();
         }

         [HttpPost]
        public async Task<IActionResult> Login(User user)
         {
           var userData = _context.Users.FirstOrDefault(u => u.Email == user.Email);

          if (userData == null)
          {
            ViewBag.Message = "Usuário e/ou senha inválidos!";
            return View();
          }

          bool passwordOk = BCrypt.Net.BCrypt.Verify(user.Password, userData.Password);

          if (passwordOk && userData != null)
          {
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name, userData.Name),
              new Claim(ClaimTypes.NameIdentifier, userData.ID.ToString()),
              new Claim(ClaimTypes.Email, userData.Email),
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            var props = new AuthenticationProperties
            {
              AllowRefresh = true,
              ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
              IsPersistent = true
            };

            await HttpContext.SignInAsync(principal, props);

            return Redirect("/");
          }
          else
          {
             ViewBag.Message = "Usuário e/ou senha inválidos!";
          }

          return View();
         }

      public async Task<IActionResult> Logout()
      {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Login", "Users");
      }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Password,Photo")] User user)
        {
            var userData = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if (userData != null) {
              ViewBag.Message = "Email já cadastrado no sistema";
             return View();
            }

            if (ModelState.IsValid)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Users");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Password,Photo")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}

