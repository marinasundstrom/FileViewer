using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileViewer.Services
{
    public interface INodeTreeLoader
    {
        Task<Node> LoadPathsAsync(NodeContext nodeContext, IEnumerable<string> paths);
    }
}