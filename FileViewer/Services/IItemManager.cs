using System.Threading.Tasks;

using FileViewer.Models;

namespace FileViewer.Services
{
    public interface IItemManager
    {
        Task<DirectoryItem> CreateDirectoryAsync(DirectoryItem parentDirectory, string name);
        Task<FileItem> CreateFileAsync(DirectoryItem parentDirectory, string name);
        Task DeleteItemAsync(Item item);
    }
}
