using System.Threading.Tasks;

namespace FileViewer.Services
{
    public sealed class FileSystem
    {
        private readonly IStorageProvider storageProvider;
        private readonly INodeTreeLoader nodeTreeLoader;
        private NodeContext nodeContext;

        public FileSystem(IStorageProvider storageProvider, INodeTreeLoader nodeTreeLoader)
        {
            this.storageProvider = storageProvider;
            this.nodeTreeLoader = nodeTreeLoader;
        }

        public async Task<Node> GetRootNodeAsync()
        {
            nodeContext = new NodeContext(storageProvider, nodeTreeLoader);
            await nodeContext.LoadAsync();
            return nodeContext.RootNode;
        }
    }
}
