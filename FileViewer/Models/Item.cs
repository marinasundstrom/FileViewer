
using FileViewer.Services;

namespace FileViewer.Models
{
    public abstract class Item
    {
        public Item(DirectoryItem containingDirectory, Node node)
        {
            ContainingDirectory = containingDirectory;
            Node = node;
        }

        public string Name
        {
            get => Node.Name;
            set => Node.Name = value;
        }

        public DirectoryItem ContainingDirectory { get; }

        public string GetDisplayName()
        {
            return Node.GetDisplayName();
        }

        public string GetFullPath()
        {
            return Node.GetFullPath();
        }

        public bool Expand(Item item)
        {
            if (this == item)
            {
                if (this is DirectoryItem d2)
                {
                    d2.IsExpanded = true;
                }
                return true;
            }

            if (this is DirectoryItem d)
            {
                foreach (var n in d.ChildItems)
                {
                    if (n.Expand(item))
                    {
                        d.IsExpanded = true;
                        return true;
                    }
                }
            }

            return false;
        }

        internal Node Node { get; }
    }
}
