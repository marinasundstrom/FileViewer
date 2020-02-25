using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Browser.Storage;

namespace FileViewer.Services
{
    public class LocalStorageProvider : IStorageProvider
    {
        private const string LocalStorageKey = "paths";
        private const string FilesJsonRequestUri = "files.json";
        private readonly LocalStorage localStorage;
        private readonly HttpClient httpClient;

        public LocalStorageProvider(LocalStorage localStorage, HttpClient httpClient)
        {
            this.localStorage = localStorage;
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<string>> LoadAsync()
        {
            var filePaths = await localStorage.GetItemAsync<IEnumerable<string>>(LocalStorageKey);

            if (filePaths == null)
            {
                var json = await httpClient.GetStringAsync(FilesJsonRequestUri);
                filePaths = JsonSerializer.Deserialize<IEnumerable<string>>(json);
                await localStorage.SetItemAsync(LocalStorageKey, filePaths);
            }

            return filePaths;
        }

        public async Task SaveAsync(IEnumerable<string> filePaths)
        {
            await localStorage.SetItemAsync(LocalStorageKey, filePaths);
        }
    }
}
