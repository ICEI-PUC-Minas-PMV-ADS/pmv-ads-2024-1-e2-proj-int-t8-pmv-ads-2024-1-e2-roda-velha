namespace RodaVelha.Models
{
    public class Like
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required int EventId { get; set; }

        // Navigation property for the relationship
        public virtual  User User { get; set; }
        public virtual  Events Event { get; set; }
    }
}
