using QLBaoDienTu.Models;
using QLThuVienPhanTan.Models;

namespace QLThuVienPhanTan.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _appDbContext;
        public BranchRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(Branch branch)
        {
            await _appDbContext.Branchs.AddAsync(branch);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
