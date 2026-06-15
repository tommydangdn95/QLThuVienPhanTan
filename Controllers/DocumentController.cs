using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLBaoDienTu.Consts;
using QLBaoDienTu.Dtos.Apis;
using QLThuVienPhanTan.Enums;
using QLThuVienPhanTan.Services;
using QLThuVienPhanTan.Utils;
using QLThuVienPhanTan.ViewModels._DocumentViewModels;
using System.Security.Claims;

namespace QLThuVienPhanTan.Controllers
{
    [Authorize(Roles = $"{RoleConst.Admin},{RoleConst.Staff}")]
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IBranchService _branchService;
        public DocumentController(IDocumentService documentService, IBranchService branchService)
        {
            this._documentService = documentService;
            this._branchService = branchService;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet("create")]
        public async Task<IActionResult> CreateAsync()
        {
            var vm = new CreateDocument();
            vm.ListDocumentType = EnumHelper.ToSelectList<DocumentType>();
            var listBranches = await _branchService.GetAllBranchAsync();
            vm.ListBranches = listBranches.Data.Select(b => new SelectListItem
            {
                Value = b.BranchId.ToString(),
                Text = b.Name
            }).ToList();

            return View(vm);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBranchAsync(CreateDocument createDocument)
        {
            if (createDocument == null)
            {
                return View(createDocument);
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

            var result = await _documentService.CreateAsync(createDocument, userId);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, $"{result.Message}");
                return View(createDocument);
            }

            return RedirectToAction("Index");
        }
    }
}
