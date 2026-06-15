using Microsoft.EntityFrameworkCore;
using QLBaoDienTu.Dtos;
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

        public async Task<PagedResult<Branch>> GetAllAsync()
        {
            var branches = await _appDbContext.Branchs.Where(x => !x.IsDeleted).ToListAsync();
            if (!branches.Any())
            {
                return PagedResult<Branch>.Empty();
            }

            return new PagedResult<Branch>(branches, branches.Count(), 1, 100000);
        }
    }
}
