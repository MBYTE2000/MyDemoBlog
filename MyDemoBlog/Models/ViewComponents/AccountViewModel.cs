using System.ComponentModel.DataAnnotations;

namespace MyDemoBlog.Models.ViewComponents
{
    public class AccountViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить")]
        public bool RememberMe { get; set; }
    }
}
