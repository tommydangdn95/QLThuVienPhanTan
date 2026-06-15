using Microsoft.AspNetCore.Mvc.RazorPages;
using QLBaoDienTu.Dtos;
using QLThuVienPhanTan.Models;

namespace QLThuVienPhanTan.Repositories
{
    public interface IBranchRepository
    {
        public Task<bool> CreateAsync(Branch branch);
        public Task<PagedResult<Branch>> GetAllAsync();
    }
}
