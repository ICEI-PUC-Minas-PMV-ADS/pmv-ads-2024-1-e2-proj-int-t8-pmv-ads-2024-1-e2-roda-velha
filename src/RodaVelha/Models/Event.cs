namespace RodaVelha.Models;

public class Event
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required string Location { get; set; }
    public string? Organizer { get; set; }
    public int Likes { get; set; }
    public required string Photo { get; set; }
    public string? Phone { get; set; }
    public required int UserId { get; set; }

    // Navigation property for the relationship
    public virtual required User User { get; set; }
}
