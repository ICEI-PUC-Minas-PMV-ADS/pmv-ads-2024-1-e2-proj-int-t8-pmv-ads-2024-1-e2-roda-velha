using Microsoft.AspNetCore.Mvc;
using RodaVelha.Data;
using RodaVelha.Models;
using System.Security.Claims;

namespace RodaVelha.Controllers
{
    public class LikeController : Controller
    {
        private readonly RodaVelhaContext _context;

        [HttpPost]
        public JsonResult LikeEvent (int eventId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            bool success = _context.Likes.Any(like => like.UserId == userId && like.EventId == eventId);
            if (success)
            {
                return Json(new { success = false });
            }
            else 
            {
                var like = new Like
                {
                    UserId = userId,
                    EventId = eventId,
                    User = _context.Users.Find(userId),
                    Event = _context.Events.Find(eventId)
                };
                _context.Likes.Add(like);
                _context.SaveChanges();

                return Json(new { success = success });
            }
            
        }
    }
}
