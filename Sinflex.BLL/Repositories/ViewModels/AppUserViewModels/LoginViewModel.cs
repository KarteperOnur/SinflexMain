using System.ComponentModel.DataAnnotations;
namespace Sinflex.BLL.Repositories.ViewModels.AppUserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email boş geçilemez")]
        [EmailAddress(ErrorMessage = "Değer email formatında olmalı")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public bool Remember { get; set; }

    }
}
