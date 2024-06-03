using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User;

public class UserDtoForCreation : UserDto
{
    [DataType(DataType.Password)]   
    [Required(ErrorMessage = "Parola Alanı Zorunludur.")]
    public string Password { get; init; }
}
