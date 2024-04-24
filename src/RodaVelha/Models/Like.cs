namespace RodaVelha.Models;

public class Like
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int EventId { get; set; }

    // Navigation property for the relationship
    public virtual required User User { get; set; }
    public virtual required Event Event { get; set; }
}
