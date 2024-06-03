using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Register;

public class RegisterDto
{
    [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Geçilemez.")]
    public string UserName {  get; init; }

    [Required(ErrorMessage = "Email Alanı Boş Geçilemez.")]
    public string Email {  get; init; }

    [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez.")]
    public string Password { get; init; }
}
