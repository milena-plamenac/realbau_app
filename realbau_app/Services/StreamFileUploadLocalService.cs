using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using realbau_app.api.Repositories.Interfaces;
using realbau_app.Interfaces;


namespace realbau_app.Services
{
    public class StreamFileUploadLocalService : IStreamFileUploadService
    {
        private IImageRepository imageRepository;

        public StreamFileUploadLocalService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<bool> UploadFile(MultipartReader reader, MultipartSection? section)
        {
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition
                );
                if (hasContentDispositionHeader)
                {
                    if (contentDisposition.DispositionType.Equals("form-data") &&
                    (!string.IsNullOrEmpty(contentDisposition.FileName.Value) ||
                    !string.IsNullOrEmpty(contentDisposition.FileNameStar.Value)))
                    {
                        string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                        byte[] fileArray;
                        using (var memoryStream = new MemoryStream())
                        {
                            await section.Body.CopyToAsync(memoryStream);
                            fileArray = memoryStream.ToArray();
                        }
                        using (var fileStream = System.IO.File.Create(Path.Combine(filePath, contentDisposition.FileName.Value)))
                        {
                            await fileStream.WriteAsync(fileArray);
                        }
                    }
                }
                section = await reader.ReadNextSectionAsync();

                var saveImageResult = this.imageRepository.Save("hausbegehung", 12, contentDisposition.FileName.Value);

                return saveImageResult.Result;
            }

            
            return true;
        }
    }
}
