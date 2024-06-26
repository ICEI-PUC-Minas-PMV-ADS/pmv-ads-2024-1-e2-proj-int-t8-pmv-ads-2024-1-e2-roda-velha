﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RodaVelha.Data;
using RodaVelha.Models;
using RodaVelha.Services;
using System.ComponentModel.DataAnnotations;

namespace RodaVelha.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly RodaVelhaContext _context;
        private readonly IUserService _userService;

        public EventsController(RodaVelhaContext context, IUserService userService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var rodaVelhaContext = _context.Events.Include(e => e.User);
            return View(await rodaVelhaContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewBag.States = GetBrazilianStates();
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,StartDate,EndDate,Location,Organizer,Phone, State")] Events @event, IFormFile Photo)
        {
            try
            {
                var user = _userService.GetCurrentUser();
                if (user != null)
                {
                    @event.UserId = user.ID;
                    @event.User = user;
                }

                if (Photo != null && Photo.Length > 0)
                {
                    var fileExtension = Path.GetExtension(Photo.FileName);
                    var fileName = $"{Guid.NewGuid()}_{DateTime.Now:yyyyMMddHHmmssfff}{fileExtension}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/events", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Photo.CopyToAsync(stream);
                    }

                    @event.Photo = "/assets/images/events/" + fileName;
                }

                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UsersController.Index), "Users");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "Houve um erro ao salvar o evento. Por favor, tente novamente. [" + ex.Message + "]";
                return View(@event);
            }
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.States = GetBrazilianStates();
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "ID", "ID", @event.UserId);
            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate,EndDate,Location,Organizer,Phone, Photo, UserId, User, Likes, State")] Events @event, IFormFile Photo)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }
            
            try
                {
                    if (Photo != null && Photo.Length > 0)
                    {
                        var fileExtension = Path.GetExtension(Photo.FileName);
                        var fileName = $"{Guid.NewGuid()}_{DateTime.Now:yyyyMMddHHmmssfff}{fileExtension}";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/events", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Photo.CopyToAsync(stream);
                        }

                        @event.Photo = "/assets/images/events/" + fileName;
                }
                else
                {
                    var eventOfUser = _context.Events.FirstOrDefault(e => e.Id == id);
                    @event.Photo = eventOfUser.Photo;
                }
               

                _context.Update(@event);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Users");
            }
            catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = "Houve um erro ao salvar o evento. Por favor, tente novamente. [" + ex.Message + "]";
                    return View(@event);
                }


            
        }
        
        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var user = _userService.GetCurrentUser();
            if (user != null)
            {
               var eventExist = _context.Events.FirstOrDefault(e => e.Id == id && user.ID == e.UserId);
               var eventFromUser = _context.Events.FirstOrDefault(e => e.UserId == user.ID);
                if (eventExist != null && eventFromUser !=null)
                {
                    _context.Remove(eventExist);
                    _context.SaveChanges();
                    return Json(new { success = true, message = "Registro excluído com sucesso" });
                }
                else if(eventFromUser != null) {
                
                    return Json(new { success = false, message = "Proibido apagar evento de outro usuário" });
                }
                  else { return Json(new { success = false, message = "Evento não existe" }); }
            }else
               { return Json(new { success = false, message = "Usuario nao logado" }); }

        }


        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
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
