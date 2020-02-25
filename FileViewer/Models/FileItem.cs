
using FileViewer.Services;

namespace FileViewer.Models
{
    public sealed class FileItem : Item
    {
        public FileItem(DirectoryItem containingDirectory, Node node)
            : base(containingDirectory, node)
        {
        }
    }
}
