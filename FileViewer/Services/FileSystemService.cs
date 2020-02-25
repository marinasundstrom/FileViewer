
using System.Threading.Tasks;

namespace FileViewer.Services
{
    public class FileSystemService
    {
        private readonly FileSystem fileSystem;

        public FileSystemService(FileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public async Task<Node> GetRootAsync()
        {
            return await fileSystem.GetRootNodeAsync();
        }
    }
}
