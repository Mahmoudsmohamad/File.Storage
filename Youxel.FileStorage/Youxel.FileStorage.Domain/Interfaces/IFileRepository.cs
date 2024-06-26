using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youxel.FileStorage.Domain.Models;

namespace Youxel.FileStorage.Domain.Interfaces
{
    public interface IFileRepository
    {
        Task SaveMetadataAsync(FileMetadata metadata);
        Task<FileMetadata> GetMetadataAsync(Guid id);
        Task DeleteMetadataAsync(Guid id);
    }
}
