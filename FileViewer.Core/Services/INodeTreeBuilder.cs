using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileViewer.Services
{
    public interface INodeTreeBuilder
    {
        Task<Node> BuildTreeAsync(NodeContext nodeContext, IDictionary<string, IList<string>> pathMap);
    }
}