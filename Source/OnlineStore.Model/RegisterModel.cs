using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Необходимо ввести логин")]
        public string Login { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; }
    }
}
