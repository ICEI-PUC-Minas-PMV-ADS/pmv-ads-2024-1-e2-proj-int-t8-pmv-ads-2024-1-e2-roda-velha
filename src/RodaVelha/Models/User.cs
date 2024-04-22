namespace RodaVelha.Models;

public class User
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; }
    public string? Photo { get; set; }

    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Event> Events { get; set; }


    // Constructor to initialize the collections
    public User()
    {
        Likes = new HashSet<Like>();
        Events = new HashSet<Event>();
    }

}
