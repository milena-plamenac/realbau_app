using Microsoft.AspNetCore.WebUtilities;

namespace realbau_app.Interfaces
{
    public interface IStreamFileUploadService
    {
        Task<bool> UploadFile(MultipartReader reader, MultipartSection section);
    }
}

