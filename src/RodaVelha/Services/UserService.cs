namespace RodaVelha.Services;

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using RodaVelha.Data;
using RodaVelha.Models;

public class UserService : IUserService
{
    private readonly RodaVelhaContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(RodaVelhaContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public User GetCurrentUser()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return null;
        }

        return _context.Users.FirstOrDefault(u => u.ID == int.Parse(userId));
    }
}
