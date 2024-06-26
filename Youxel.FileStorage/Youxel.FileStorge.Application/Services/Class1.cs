using Microsoft.AspNetCore.Http;
using Youxel.FileStorage.Domain.Interfaces;
using Youxel.FileStorage.Domain.Models;
using Youxel.FileStorage.Infrastrucure.Interfaces;
using Youxel.FileStorge.Application.Interfaces;


namespace Youxel.FileStorge.Application.Services
{

   

    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IStorageClient _storageClient;

        public FileService(IFileRepository fileRepository, IStorageClient storageClient)
        {
            _fileRepository = fileRepository;
            _storageClient = storageClient;
        }

        public async Task<Guid> UploadFileAsync(IFormFile file)
        {
            var fileId = Guid.NewGuid();
           
            var metadata = new FileMetadata
            {
                Id = fileId,
                FileName = file.FileName,
                ContentType = file.ContentType,
                Size = file.Length,
                UploadDate = DateTime.UtcNow
            };

            await _storageClient.UploadFileAsync(fileId, file.OpenReadStream());
            await _fileRepository.SaveMetadataAsync(metadata);
            return fileId;
        }

        public async Task<Stream> DownloadFileAsync(Guid id)
        {
            var metadata = await _fileRepository.GetMetadataAsync(id);
            return metadata == null ? null : await _storageClient.DownloadFileAsync(id);
        }

        public async Task<bool> DeleteFileAsync(Guid id)
        {
            var metadata = await _fileRepository.GetMetadataAsync(id);
            if (metadata == null) return false;
            await _storageClient.DeleteFileAsync(id);
            await _fileRepository.DeleteMetadataAsync(id);
            return true;
        }
    }
}
