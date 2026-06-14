using Microsoft.AspNetCore.Identity;
using QLBaoDienTu.Consts;
using QLBaoDienTu.Dtos;
using QLBaoDienTu.Models._Users;
using QLBaoDienTu.Utils;
using QLThuVienPhanTan.Enums;
using QLThuVienPhanTan.Utils;
using QLThuVienPhanTan.ViewModels._UserViewModels;
using System.Security.Claims;
using IResult = QLBaoDienTu.Dtos.IResult;

namespace QLBaoDienTu.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<AppUser> GetUserById(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user;
        }

        public async Task<IResult> CreateUser(CreateUser createUser)
        {
            var appUser = new AppUser()
            {
                FullName = createUser.FullName,
                UserName = createUser.Email,
                Email = createUser.Email,
                EmailConfirmed = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
            };

            var parseRole = createUser.RoleId.ToEnum<RoleType>();
            var role = RoleConst.GetRoleName(parseRole!.Value);

            var result = await _userManager.CreateAsync(appUser, createUser.Password);
            if (!result.Succeeded)
            {
                return Result.Failed($"Create user failed: {result.Errors.ToError()}");
            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, role.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            result = await _userManager.AddClaimsAsync(appUser, claims);

            if (!result.Succeeded)
            {
                return Result.Failed($"Create user failed: {result.Errors.ToError()}");
            }

            result = await _userManager.AddToRoleAsync(appUser, RoleConst.Admin);

            if (!result.Succeeded)
            {
                return Result.Failed($"Create user failed: {result.Errors.ToError()}");
            }

            return Result.Success("Create user successfully");
        }
    }
}
