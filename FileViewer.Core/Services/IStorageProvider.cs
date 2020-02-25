using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileViewer.Services
{
    public interface IStorageProvider
    {
        Task<IEnumerable<string>> LoadAsync();
        Task SaveAsync(IEnumerable<string> paths);
    }
}
