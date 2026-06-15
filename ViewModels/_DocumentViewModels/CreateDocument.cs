using Microsoft.AspNetCore.Mvc.Rendering;

namespace QLThuVienPhanTan.ViewModels._DocumentViewModels
{
    public class CreateDocument
    {
        public string Title { get; set; }
        public Guid BranchId { get; set; }
        public List<SelectListItem> ListBranches { get; set; }
        public int DocumentType { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }

        public CreateDocument()
        {
            this.ListBranches = new List<SelectListItem>();
        }
    }
}
