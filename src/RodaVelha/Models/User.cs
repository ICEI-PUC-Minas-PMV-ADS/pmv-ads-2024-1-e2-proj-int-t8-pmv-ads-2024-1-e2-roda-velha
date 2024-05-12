using System.ComponentModel.DataAnnotations;

namespace RodaVelha.Models;

public class User
{
    public int ID { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [Display(Name ="Nome")]
    public required string Name { get; set; }
    [Required(ErrorMessage ="Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    [Display(Name ="Email")]
    public required string Email { get; set; }
    [Required(ErrorMessage = "A senha é obrigatória.")]
    [DataType(DataType.Password)]
    [Display(Name ="Senha")]
    public required string Password { get; set; }
    public string? Photo { get; set; }

    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Events> Events { get; set; }


    // Constructor to initialize the collections
    public User()
    {
        Likes = new HashSet<Like>();
        Events = new HashSet<Events>();
    }

}
