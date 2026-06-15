using QLThuVienPhanTan.Models;

namespace QLThuVienPhanTan.Repositories
{
    public interface IDocumentRepository
    {
        public Task<bool> CreateAsync(Document document);
        public Task<bool> CreateDocumentBranch(DocumentBranch documentBranch);
    }
}
