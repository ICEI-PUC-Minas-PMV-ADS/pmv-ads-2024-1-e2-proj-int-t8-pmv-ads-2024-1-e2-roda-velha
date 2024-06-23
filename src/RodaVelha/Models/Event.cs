using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RodaVelha.Models;

public class Events
{
    public int Id { get; set; }

    [Required(ErrorMessage ="O nome do evento é obrigatório.")]
    [Display(Name ="Nome")]
    public required string Name { get; set; }

    [Required(ErrorMessage ="A descrição do evento é obrigatória.")]
    [Display(Name ="Descrição")]
    public required string Description { get; set; }

    [Required(ErrorMessage ="A data de início do evento é obrigatória.")]
    [Display(Name ="Data de Início")]
    public required DateTime StartDate { get; set; }

    [Display(Name ="Data de Término")]
    public DateTime? EndDate { get; set; }

    [Required(ErrorMessage ="A localização do evento é obrigatória.")]
    [Display(Name ="Localização")]
    public required string Location { get; set; }
    
    [Display(Name ="Organizador")]    
    public string? Organizer { get; set; }
    
    public int Likes { get; set; }

    [Required(ErrorMessage = "A foto do evento de capa é obrigatória.")]
    [Display(Name ="Capa")]    
    public required string Photo { get; set; }
    
    [Display(Name ="Telefone")]
    public string? Phone { get; set; }
    
    public required int UserId { get; set; }

    // Navigation property for the relationship
    public virtual required User User { get; set; }
}

