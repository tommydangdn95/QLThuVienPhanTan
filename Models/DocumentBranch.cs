using QLBaoDienTu.Models;

namespace QLThuVienPhanTan.Models
{
    public class DocumentBranch : BaseModel
    {
        public Guid DocumentId { get; set; }
        public Guid BranchId { get; set; }
    }
}
