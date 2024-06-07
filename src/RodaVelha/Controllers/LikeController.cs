using Microsoft.AspNetCore.Mvc;
using RodaVelha.Data;
using RodaVelha.Models;
using System.Security.Claims;

namespace RodaVelha.Controllers
{
    public class LikeController : Controller
    {
        private readonly RodaVelhaContext _context;

        public LikeController(RodaVelhaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult LikeEvent (int eventId)
        {
            var userLogged = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userLogged != null)
            {
                var userId = int.Parse(userLogged);


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
                        EventId = eventId
                       
                    };
                    _context.Likes.Add(like);
                    _context.SaveChanges();

                    return Json(new { success = true });
                }
            }
            else
                return Json(new { success = false });

            
            
            
        }
    }
}
