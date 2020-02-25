using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileViewer.Services
{
    public sealed class NodeTreeLoader : INodeTreeLoader
    {
        private readonly INodeTreeBuilder nodeTreeBuilder;

        public NodeTreeLoader(INodeTreeBuilder nodeTreeBuilder)
        {
            this.nodeTreeBuilder = nodeTreeBuilder;
        }

        public async Task<Node> LoadPathsAsync(NodeContext nodeContext, IEnumerable<string> paths)
        {
            var filePathMap = new PathMap();

            foreach (var filename in paths)
            {
                filePathMap.AddPath(filename);
            }

            return await nodeTreeBuilder.BuildTreeAsync(nodeContext, filePathMap.GetDictionary());
        }
    }
}
