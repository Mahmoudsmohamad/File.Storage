
using Youxel.FileStorage.Infrastrucure.Interfaces;

namespace Youxel.FileStorage.Infrastrucure.Services
{
    public class StorageClient : IStorageClient
    {
        private readonly Dictionary<Guid, byte[]> _storage = new Dictionary<Guid, byte[]>();

        public Task UploadFileAsync(Guid id, Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                _storage[id] = memoryStream.ToArray();
            }
            return Task.CompletedTask;
        }

        public Task<Stream> DownloadFileAsync(Guid id)
        {
            _storage.TryGetValue(id, out var data);
            var memoryStream = new MemoryStream(data ?? new byte[0]);
            return Task.FromResult<Stream>(memoryStream);
        }

        public Task DeleteFileAsync(Guid id)
        {
            _storage.Remove(id);
            return Task.CompletedTask;
        }
    }

}
