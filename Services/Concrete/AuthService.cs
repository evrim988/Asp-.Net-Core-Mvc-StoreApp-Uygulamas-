using AutoMapper;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IMapper _mapper;
        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public async Task<IdentityResult> CreateUser(UserDtoForCreation model)
        {
            var user = _mapper.Map<IdentityUser>(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Yeni Kullanıcı Oluşturulamadı.");
            }

            if (model.Roles.Count > 0)
            {
                foreach (var item in model.Roles)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, item);
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception("Kullanıcı Rolü Oluşturulamadı.");
                    }

                }

            }

            return result;
        }

        public async Task<UserDtoForUpdate> GetByUserForUpdate(string userName)
        {
            var user = await GetByUserName(userName);

            var userModel = _mapper.Map<UserDtoForUpdate>(user);
            userModel.Roles = new HashSet<string>(Roles.Select(s => s.Name)); //bütün rolleri aldık.
            userModel.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user)); //kullanıcının rollerini aldık.
            return userModel;

        }

        public async Task<IdentityUser> GetByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return user;
            }
            throw new Exception("Kullanıcı Bulunamadı");
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }


        public async Task Update(UserDtoForUpdate model)
        {
            var user = await GetByUserName(model.UserName);
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;

            if (user != null)
            {
                var result = await _userManager.UpdateAsync(user);
                if (model.Roles.Count > 0)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    var r2 = await _userManager.AddToRolesAsync(user, model.UserRoles);
                }
                return;
            }
            throw new Exception("Kullanıcı Güncellenemedi");
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await GetByUserName(model.UserName);
            if (user != null)
            {
                await _userManager.RemovePasswordAsync(user); //mevcut şifreyi sildik.
                var result = await _userManager.AddPasswordAsync(user, model.Password); //yeni şifreyi kaydettik.
                return result;
            }
            throw new Exception("Kullanıcı Bulunamadı.");
        }

        public async Task<IdentityResult> DeleteByUser(string userName)
        {
            var user = await GetByUserName(userName);
            return await _userManager.DeleteAsync(user);
        }
    }
}
