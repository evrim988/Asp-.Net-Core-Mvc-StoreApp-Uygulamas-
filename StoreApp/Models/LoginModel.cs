using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class LoginModel
    {
        private string _returnUrl; 

        [Required(ErrorMessage = "Name alanı boş geçilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Parola alanı boş geçilemez.")]
        public string Password { get; set; }

        public string RetunUrl //ürünü satın almak isteyen kullanıcıya login sayfasına yönlendirmek için kullanacağız.
        {
            get {
                if (_returnUrl == null)
                    return "/";
                return _returnUrl;
            }
            set { _returnUrl = value; }
        }
    }
}
