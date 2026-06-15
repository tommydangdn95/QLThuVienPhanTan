using QLBaoDienTu.Dtos;
using QLThuVienPhanTan.Enums;
using QLThuVienPhanTan.Repositories;
using QLThuVienPhanTan.Utils;
using QLThuVienPhanTan.ViewModels._DocumentViewModels;
using IResult = QLBaoDienTu.Dtos.IResult;

namespace QLThuVienPhanTan.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            this._documentRepository = documentRepository;
        }

        public async Task<IResult> CreateAsync(CreateDocument createDocument, Guid submitUserId)
        {
            var document = new Models.Document()
            {
                Title = createDocument.Title,
                DocumentType = createDocument.DocumentTypeId.ToEnum<DocumentType>()!.Value,
                CreatedDate = DateTime.Now,
                CreatedBy = submitUserId
            };

            var result = await _documentRepository.CreateAsync(document);
            if (!result)
            {
                return Result.Failed($"Failed to create new document");
            }

            var documentBranch = new Models.DocumentBranch()
            {
                DocumentId = document.Id,
                BranchId = createDocument.BranchId,
                CreatedDate = DateTime.Now,
                CreatedBy = submitUserId
            };

            result = await _documentRepository.CreateDocumentBranch(documentBranch);
            if (!result)
            {
                return Result.Failed($"Failed to create new document branch");
            }

            return Result.Success($"Create new document branch successfully");
        }
    }
}
