using QLBaoDienTu.Models;

namespace QLThuVienPhanTan.Models
{
    public class Branch : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
