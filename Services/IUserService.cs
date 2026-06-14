using QLBaoDienTu.Models._Users;
using QLThuVienPhanTan.ViewModels._UserViewModels;
using IResult = QLBaoDienTu.Dtos.IResult;

namespace QLBaoDienTu.Services
{
    public interface IUserService
    {
        public Task<AppUser> GetUserById(Guid userId);
        public Task<IResult> CreateUser(CreateUser createUser);
    }
}
