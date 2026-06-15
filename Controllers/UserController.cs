using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLBaoDienTu.Consts;
using QLBaoDienTu.Services;
using QLThuVienPhanTan.Enums;
using QLThuVienPhanTan.Utils;
using QLThuVienPhanTan.ViewModels._UserViewModels;

namespace QLThuVienPhanTan.Controllers
{
    [Authorize(Roles = RoleConst.Admin)]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("create")]
        public Task<IActionResult> Create()
        {
            var vm = new CreateUser();
            vm.RoleList = EnumHelper.ToSelectList<RoleType>();
            return Task.FromResult<IActionResult>(View(vm));
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUserAsync(CreateUser createUser)
        {
            if (createUser == null)
            {
                return View(createUser);
            }

            var result = await _userService.CreateUser(createUser);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, $"{result.Message}");
                return View(createUser);
            }

            return RedirectToAction("Index");
        }
    }
}
