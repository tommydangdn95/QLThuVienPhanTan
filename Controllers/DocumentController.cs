using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLBaoDienTu.Consts;
using QLBaoDienTu.Dtos.Apis;
using QLThuVienPhanTan.Services;
using QLThuVienPhanTan.ViewModels._BranchViewModels;
using QLThuVienPhanTan.ViewModels._DocumentViewModels;
using System.Security.Claims;

namespace QLThuVienPhanTan.Controllers
{
    [Authorize(Roles = $"{RoleConst.Admin},{RoleConst.Staff}")]
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult CreateAsync()
        {
            return View();
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
