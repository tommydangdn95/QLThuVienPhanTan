using QLBaoDienTu.Dtos;
using QLThuVienPhanTan.Dtos.ApplicationDtos._Branch;
using QLThuVienPhanTan.ViewModels._BranchViewModels;
using IResult = QLBaoDienTu.Dtos.IResult;

namespace QLThuVienPhanTan.Services
{
    public interface IBranchService
    {
        public Task<IResult> CreateBranchAsync(CreateBranch model, Guid createUserId);
        public Task<IResultData<List<BranchItemDto>>> GetAllBranchAsync();
    }
}
