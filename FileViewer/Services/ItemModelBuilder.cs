using FileViewer.Models;

namespace FileViewer.Services
{
    public sealed class ItemModelBuilder : IItemModelBuilder
    {
        public Item CreateModel(Node node)
        {
            return CreateModelCore(null, node);
        }

        private Item CreateModelCore(DirectoryItem parent, Node node)
        {
            if (node.IsFile)
            {
                return new FileItem(parent, node);
            }
            else
            {
                var directoryItem = new DirectoryItem(parent, node);

                foreach (var childNode in node.Children)
                {
                    directoryItem.ChildItems.Add(CreateModelCore(directoryItem, childNode));
                }

                return directoryItem;
            }
        }
    }
}
