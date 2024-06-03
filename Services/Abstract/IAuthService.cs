using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles {  get; }
        
        IEnumerable<IdentityUser> GetUsers();

        Task<IdentityResult> CreateUser(UserDtoForCreation model);

        Task<UserDtoForUpdate> GetByUserForUpdate(string userName); //kullanıcıya ait rol tanımları için böyle bir method yazdık.

        Task<IdentityUser> GetByUserName(string userName);

        Task Update(UserDtoForUpdate model);

        Task<IdentityResult> ResetPassword(ResetPasswordDto model);

        Task<IdentityResult> DeleteByUser(string userName);
    }
}
