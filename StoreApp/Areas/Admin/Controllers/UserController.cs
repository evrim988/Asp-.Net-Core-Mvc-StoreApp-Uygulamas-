using Entities.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.AuthService.GetUsers();
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_manager.AuthService.Roles.Select(s=>s.Name).ToList()), //rolleri view sayfamıza taşıış olduk.

            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]UserDtoForCreation model)
        {
            var result = await _manager.AuthService.CreateUser(model);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")]string id)
        {
            var user = await _manager.AuthService.GetByUserForUpdate(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate model)
        {
            if (ModelState.IsValid)
            {
                await _manager.AuthService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")]string id)
        {
            return View(new ResetPasswordDto()
            {
                UserName = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordDto model)
        {
            var result = await _manager.AuthService.ResetPassword(model);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser([FromForm]UserDto model)
        {
            var result = await _manager.AuthService.DeleteByUser(model.UserName);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }
    }
}
