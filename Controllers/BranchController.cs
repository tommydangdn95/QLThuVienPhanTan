using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLBaoDienTu.Consts;
using QLBaoDienTu.Dtos.Apis;
using QLThuVienPhanTan.Services;
using QLThuVienPhanTan.ViewModels._BranchViewModels;
using QLThuVienPhanTan.ViewModels._UserViewModels;
using System.Security.Claims;

namespace QLThuVienPhanTan.Controllers
{
    [Authorize(Roles = RoleConst.Admin)]
    [Route("[controller]")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            this._branchService = branchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult CreateAsync()
        {
            var vm = new CreateBranch();
            return View(vm);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBranchAsync(CreateBranch createBranch)
        {
            if (createBranch == null)
            {
                return View(createBranch);
            }

            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return Unauthorized(new ApiErrorResponse<string>
                (
                    "User not authenticated",
                    StatusCodes.Status401Unauthorized)
                {

                });
            }

            var result = await _branchService.CreateBranchAsync(createBranch, userId);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, $"{result.Message}");
                return View(createBranch);
            }

            return RedirectToAction("Index");
        }
    }
}
