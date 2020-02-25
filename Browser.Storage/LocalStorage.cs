using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Browser.Storage
{
    public sealed class LocalStorage
    {
        private readonly IJSRuntime jsRuntime;

        public LocalStorage(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async ValueTask<T> GetItemAsync<T>(string key)
        {
            var result = await jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (result == null)
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(result);
        }

        public ValueTask SetItemAsync(string key, object value)
        {
            var obj = JsonSerializer.Serialize(value);
            return jsRuntime.InvokeVoidAsync("localStorage.setItem", key, obj);
        }

        public ValueTask RemoveItemAsync(string key)
        {
            return jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public ValueTask ClearAsync()
        {
            return jsRuntime.InvokeVoidAsync("localStorage.clear");
        }
    }
}
