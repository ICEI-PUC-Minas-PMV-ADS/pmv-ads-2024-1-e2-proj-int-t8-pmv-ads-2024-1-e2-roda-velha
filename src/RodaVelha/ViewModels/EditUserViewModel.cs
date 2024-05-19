using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RodaVelha.ViewModels
{
    public class EditUserViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name="Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [Display(Name="Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name="Nova senha")]
        public string? NewPassword { get; set; } = null;

        [Display(Name="Foto")]
        public string? Photo { get; set; }
    }
}
