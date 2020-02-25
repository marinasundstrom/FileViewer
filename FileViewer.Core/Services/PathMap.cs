#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace FileViewer.Services
{
    public sealed class PathMap
    {
        private readonly IDictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();

        public IDictionary<string, IList<string>> GetDictionary()
        {
            return dictionary;
        }

        public void AddPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new System.ArgumentException("message", nameof(path));
            }

            var filenameComponents = path.Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);

            ProcessPathComponents(filenameComponents);
        }

        private void ProcessPathComponents(string[] pathComponents)
        {
            var lastComponent = pathComponents[^1];
            var precedingComponents = pathComponents[..^1];

            var path = string.Join("/", precedingComponents);

            if (!GetDictionary().TryGetValue(path, out var childComponents))
            {
                // Add an entry for the path.

                childComponents = new List<string>();
                GetDictionary().Add(path, childComponents);
            }

            if (!childComponents.Contains(lastComponent))
            {
                // Add child component to path.

                childComponents.Add(lastComponent);
            }

            if (precedingComponents.Any())
            {
                // Process the preceeding components

                ProcessPathComponents(precedingComponents);
            }
        }
    }
}
