using QLBaoDienTu.Dtos;
using QLThuVienPhanTan.Repositories;
using QLThuVienPhanTan.ViewModels._BranchViewModels;
using IResult = QLBaoDienTu.Dtos.IResult;

namespace QLThuVienPhanTan.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        public BranchService(IBranchRepository branchRepository)
        {
            this._branchRepository = branchRepository;
        }
        public async Task<IResult> CreateBranchAsync(CreateBranch model, Guid createUserId)
        {
            var branch = new QLThuVienPhanTan.Models.Branch
            {
                Name = model.Name,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                Description = model.Description,
                CreatedBy = createUserId,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            var result = await _branchRepository.CreateAsync(branch);
            if (!result)
            {
                return Result.Failed($"Create new branch failed");
            }

            return Result.Success("Create new branch successfully");
        }
    }
}
