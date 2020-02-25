using System.Linq;
using System.Threading.Tasks;

namespace FileViewer.Services
{
    public class NodeContext
    {
        private readonly IStorageProvider storageProvider;
        private readonly INodeTreeLoader nodeTreeFactory;

        public NodeContext(IStorageProvider storageProvider, INodeTreeLoader nodeTreeLoader)
        {
            this.storageProvider = storageProvider;
            nodeTreeFactory = nodeTreeLoader;
        }

        public Node RootNode { get; private set; }

        public async Task LoadAsync()
        {
            var filePaths = await storageProvider.LoadAsync();
            RootNode = await nodeTreeFactory.LoadPathsAsync(this, filePaths);
        }

        public async Task SaveAsync()
        {
            var fileNodes = RootNode.GetAllChildrenRecursively();
            var filePaths = fileNodes.Select(x => x.GetFullPath().TrimStart('/'));
            await storageProvider.SaveAsync(filePaths);
        }
    }
}
