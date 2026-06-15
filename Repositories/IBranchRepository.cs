using QLThuVienPhanTan.Models;

namespace QLThuVienPhanTan.Repositories
{
    public interface IBranchRepository
    {
        public Task<bool> CreateAsync(Branch branch);
    }
}
