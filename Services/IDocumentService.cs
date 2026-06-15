using QLThuVienPhanTan.ViewModels._DocumentViewModels;
using IResult = QLBaoDienTu.Dtos.IResult;

namespace QLThuVienPhanTan.Services
{
    public interface IDocumentService
    {
        public Task<IResult> CreateAsync(CreateDocument createDocument, Guid submitUserId);
    }
}
