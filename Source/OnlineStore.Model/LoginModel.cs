using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Неверный логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Неверный пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
