
using FileViewer.Services;

using Xunit;

namespace FileViewer.Tests
{
    public class PathMapTest
    {
        [Fact]
        public void SinglePath()
        {
            var filePathMap = new PathMap();

            var paths = new[]
            {
                "a/b",
            };

            foreach (var path in paths)
            {
                filePathMap.AddPath(path);
            }

            var dictionary = filePathMap.GetDictionary();

            Assert.True(dictionary[string.Empty].Contains("a"));
            Assert.True(dictionary["a"].Contains("b"));
        }

        [Fact]
        public void MultiplePaths()
        {
            var filePathMap = new PathMap();

            var paths = new[]
            {
                "a1/b",
                "a2/c",
                "a1/d/g"
            };

            foreach (var path in paths)
            {
                filePathMap.AddPath(path);
            }

            var dictionary = filePathMap.GetDictionary();

            Assert.True(dictionary["a1"].Count == 2);

            Assert.True(dictionary[string.Empty].Contains("a1"));

            Assert.True(dictionary["a1"].Contains("b"));
            Assert.True(dictionary["a1"].Contains("d"));

            Assert.True(dictionary["a1/d"].Contains("g"));

            Assert.True(dictionary["a2"].Count == 1);

            Assert.True(dictionary[string.Empty].Contains("a2"));

            Assert.True(dictionary["a2"].Contains("c"));
        }
    }
}
