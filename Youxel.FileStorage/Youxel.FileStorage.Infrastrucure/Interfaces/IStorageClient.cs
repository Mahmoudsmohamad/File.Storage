namespace Youxel.FileStorage.Infrastrucure.Interfaces
{
    public interface IStorageClient
    {
        Task UploadFileAsync(Guid id, Stream stream);
        Task<Stream> DownloadFileAsync(Guid id);
        Task DeleteFileAsync(Guid id);
    }
}
