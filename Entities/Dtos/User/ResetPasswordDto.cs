using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class ResetPasswordDto
    {
        public string UserName {  get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola Alanı Boş Geçilemez.")]
        public string Password { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola Tekrar Alanı Boş Geçilemez.")]
        [Compare("Password", ErrorMessage = "Parolalar Birbiriyle Eşleşmiyor.")]
        public string ConfirmPassword { get; init; }
    }
}
