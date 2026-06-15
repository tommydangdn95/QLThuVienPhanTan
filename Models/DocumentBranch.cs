using QLBaoDienTu.Models;

namespace QLThuVienPhanTan.Models
{
    public class DocumentBranch : BaseModel
    {
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
