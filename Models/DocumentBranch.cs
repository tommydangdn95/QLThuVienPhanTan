using QLBaoDienTu.Models;

namespace QLThuVienPhanTan.Models
{
    public class DocumentBranch : BaseModel
    {
        public Guid DocumentBranchId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid BranchId { get; set; }
    }
}
