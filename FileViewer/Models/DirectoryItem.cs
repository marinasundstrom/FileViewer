using System.Collections.Generic;
using System.Linq;

using FileViewer.Services;

namespace FileViewer.Models
{
    public sealed class DirectoryItem : Item
    {
        public DirectoryItem(DirectoryItem containingDirectory, Node node)
            : base(containingDirectory, node)
        {
            ChildItems = new List<Item>();
        }

        public IList<Item> ChildItems { get; }

        public bool IsExpanded { get; set; }

        public void Expand()
        {
            IsExpanded = true;
        }

        public void ExpandAll()
        {
            Expand();

            foreach (var childItem in ChildItems.OfType<DirectoryItem>())
            {
                childItem.ExpandAll();
            }
        }
    }
}
