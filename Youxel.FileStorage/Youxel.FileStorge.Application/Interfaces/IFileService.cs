
using Microsoft.AspNetCore.Http;
using Youxel.FileStorge.Application.Services;


namespace Youxel.FileStorge.Application.Interfaces
{
    public interface IFileService
    {
        Task<Guid> UploadFileAsync(IFormFile file);
        Task<Stream> DownloadFileAsync(Guid id);
        Task<bool> DeleteFileAsync(Guid id);
    }
}
