using System.Threading.Tasks;

using FileViewer.Services;

using Moq;

using Xunit;

namespace FileViewer.Tests
{
    public class NodeTreeBuilderTest
    {
        [Fact]
        public async Task SinglePath()
        {
            var filePathMap = new PathMap();

            var paths = new[]
            {
                "/a/b",
            };

            foreach (var path in paths)
            {
                filePathMap.AddPath(path);
            }

            var dictionary = filePathMap.GetDictionary();

            var nodeTreeBuilder = new NodeTreeBuilder();

            var storageProviderMock = new Mock<IStorageProvider>();
            var nodeTreeLoader = new NodeTreeLoader(nodeTreeBuilder);

            var nodeContext = new NodeContext(storageProviderMock.Object, nodeTreeLoader);
            var rootNode = await nodeTreeBuilder.BuildTreeAsync(nodeContext, dictionary);

            Assert.NotNull(rootNode.GetChildNode("a"));
            Assert.NotNull(rootNode.GetChildNode("a")?.GetChildNode("b"));
        }

        [Fact]
        public async Task MultiplePaths()
        {
            var filePathMap = new PathMap();

            var paths = new[]
            {
                "/a1/b",
                "/a2/c",
                "/a1/d/g"
            };

            foreach (var path in paths)
            {
                filePathMap.AddPath(path);
            }

            var dictionary = filePathMap.GetDictionary();

            var nodeTreeBuilder = new NodeTreeBuilder();

            var storageProviderMock = new Mock<IStorageProvider>();
            var nodeTreeLoader = new NodeTreeLoader(nodeTreeBuilder);

            var nodeContext = new NodeContext(storageProviderMock.Object, nodeTreeLoader);
            var rootNode = await nodeTreeBuilder.BuildTreeAsync(nodeContext, dictionary);

            Assert.NotNull(rootNode.GetChildNode("a1"));

            Assert.NotNull(rootNode.GetChildNode("a1")?.GetChildNode("b"));
            Assert.NotNull(rootNode.GetChildNode("a1")?.GetChildNode("d"));

            Assert.NotNull(rootNode.GetChildNode("a1")?.GetChildNode("d")?.GetChildNode("g"));
        }
    }
}
