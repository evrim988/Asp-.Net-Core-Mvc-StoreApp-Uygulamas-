using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu Bir Alandır.")]
        public string UserName { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Zorunlu Bir Alandır.")]
        public string Email {  get; init; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber {  get; init; }

        public HashSet<String> Roles { get; set; } = new HashSet<String>();
    }
}
