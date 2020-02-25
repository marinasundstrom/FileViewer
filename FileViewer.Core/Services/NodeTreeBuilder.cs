#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileViewer.Services
{
    public sealed class NodeTreeBuilder : INodeTreeBuilder
    {
        private IDictionary<string, IList<string>>? pathMap;

        public Task<Node> BuildTreeAsync(NodeContext nodeContext, IDictionary<string, IList<string>> pathMap)
        {
            this.pathMap = pathMap ?? throw new ArgumentNullException(nameof(pathMap));

            return BuildNode(nodeContext, null, string.Empty, pathMap[string.Empty]);
        }

        private async Task<Node> BuildNode(NodeContext nodeContext, Node? parentNode, string name, IList<string>? children)
        {
            Node node;

            if (parentNode == null)
            {
                node = new RootNode(nodeContext);
            }
            else
            {
                node = new Node(parentNode, name);
            }

            if (name?.Contains(".") ?? false)
            {
                node.IsFile = true;

            }
            else
            {
                if (children != null)
                {
                    await BuildChildNodes(nodeContext, name!, children, node);
                }
            }

            if (parentNode != null)
            {
                parentNode.AddNodeCore(node);
            }

            return node;
        }

        private async Task BuildChildNodes(NodeContext nodeContext, string path, IList<string> children, Node node)
        {
            foreach (var entry in children)
            {
                var fullPath = string.IsNullOrEmpty(path) ? entry : $"{path}/{entry}";
                if (pathMap!.ContainsKey(fullPath))
                {
                    await BuildNode(nodeContext, node, entry, pathMap[fullPath]);
                }
                else
                {
                    await BuildNode(nodeContext, node, entry, null);
                }
            }
        }
    }
}
