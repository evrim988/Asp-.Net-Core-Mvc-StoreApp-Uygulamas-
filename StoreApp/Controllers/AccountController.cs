using Entities.Dtos.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Name);
                if(user != null)
                {
                    await _signInManager.SignOutAsync();
                    if((await _signInManager.PasswordSignInAsync(user,model.Password,false,false)).Succeeded)
                    {
                        return Redirect(model.RetunUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Error", "Kullanıcı Adı Veya Şifre Yanlış.");

            }
            return View();
        }

        public async Task<IActionResult> LogOut([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterDto model)
        {
            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password); //yeni kullanıcı oluşturduk.

            if(result.Succeeded)  //result işlemi başarılıysa,
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User"); //rol tanımını gerçekleştirdik.

                if (roleResult.Succeeded)
                    return RedirectToAction("Login", new { ReturnUrl = "/" }); //rol kayıt işlemi başarılı olduysa Login ekranına yönlendirir.
            }
            else
            {
                foreach (var item in result.Errors)  //eğer bir hatayla karşılaşıldıysa bunu ekrana verir.
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }

        public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")]string ReturnUrl)
        {
            return View();
        }
    }
}
