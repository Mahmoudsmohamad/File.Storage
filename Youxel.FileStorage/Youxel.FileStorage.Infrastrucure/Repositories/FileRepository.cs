using Youxel.FileStorage.Domain.Interfaces;
using Youxel.FileStorage.Domain.Models;


namespace Youxel.FileStorage.Infrastrucure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly Dictionary<Guid, FileMetadata> _metadataStorage = new Dictionary<Guid, FileMetadata>();

        public Task SaveMetadataAsync(FileMetadata metadata)
        {
            _metadataStorage[metadata.Id] = metadata;
            return Task.CompletedTask;
        }

        public Task<FileMetadata> GetMetadataAsync(Guid id)
        {
            _metadataStorage.TryGetValue(id, out var metadata);
            return Task.FromResult(metadata);
        }

        public Task DeleteMetadataAsync(Guid id)
        {
            _metadataStorage.Remove(id);
            return Task.CompletedTask;
        }
    }
}
