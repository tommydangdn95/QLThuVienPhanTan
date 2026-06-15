using QLBaoDienTu.Dtos;
using QLThuVienPhanTan.ViewModels._BranchViewModels;
using IResult = QLBaoDienTu.Dtos.IResult;

namespace QLThuVienPhanTan.Services
{
    public interface IBranchService
    {
        public Task<IResult> CreateBranchAsync(CreateBranch model, Guid createUserId);
    }
}
