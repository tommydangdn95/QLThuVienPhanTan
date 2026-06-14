using Microsoft.AspNetCore.Mvc.Rendering;
using QLBaoDienTu.Consts;

namespace QLThuVienPhanTan.ViewModels._UserViewModels
{
    public class CreateUser
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public List<SelectListItem> RoleList { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public CreateUser()
        {
            this.RoleList = new List<SelectListItem>();
        }
    }
}
