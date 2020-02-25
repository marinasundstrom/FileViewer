using System.Threading.Tasks;

using FileViewer.Models;

namespace FileViewer.Services
{
    public sealed class ItemManager : IItemManager
    {
        public async Task<DirectoryItem> CreateDirectoryAsync(DirectoryItem containingDirectory, string name)
        {
            var directoryNode = await containingDirectory.Node.CreateDirectoryAsync(name);
            var dictionaryItem = new DirectoryItem(containingDirectory, directoryNode);
            containingDirectory.ChildItems.Add(dictionaryItem);
            return dictionaryItem;
        }

        public async Task<FileItem> CreateFileAsync(DirectoryItem containingDirectory, string name)
        {
            var fileNode = await containingDirectory.Node.CreateFileAsync(name);
            var fileItem = new FileItem(containingDirectory, fileNode);
            containingDirectory.ChildItems.Add(fileItem);
            return fileItem;
        }

        public async Task DeleteItemAsync(Item item)
        {
            await item.Node.DeleteAsync();
            item.ContainingDirectory.ChildItems.Remove(item);
        }
    }
}
