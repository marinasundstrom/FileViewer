#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileViewer.Services
{

    public class Node : IEnumerable<Node>
    {
        internal Node(Node? parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        internal Node(string name) : this(null, name)
        {
            Name = name;
        }

        public Node? Parent { get; set; }

        public string Name { get; set; }

        public bool IsFile { get; set; }

        public List<Node> Children { get; set; } = new List<Node>();

        protected virtual NodeContext Context => Parent!.Context;

        internal async Task<Node> AddNodeAsync(Node node)
        {
            AddNodeCore(node);

            await Context.SaveAsync();

            return node;
        }

        internal void AddNodeCore(Node node)
        {
            node.Parent = this;
            Children.Add(node);
        }

        public async Task<Node> CreateFileAsync(string name)
        {
            var node = new Node(name)
            {
                IsFile = true
            };

            return await AddNodeAsync(node);
        }

        public async Task<Node> CreateDirectoryAsync(string name)
        {
            var node = new Node(name);

            return await AddNodeAsync(node);
        }

        public virtual string GetDisplayName()
        {
            return Name;
        }

        public string GetFullPath()
        {
            if (Parent == null)
            {
                return Name;
            }

            return $"{Parent.GetFullPath()}/{Name}";
        }

        public IEnumerable<Node> GetAllChildrenRecursively()
        {
            foreach (var child in Children)
            {
                yield return child;

                foreach (var innerChild in child.GetAllChildrenRecursively())
                {
                    yield return innerChild;
                }
            }
        }

        public Node GetChildNodeFromPath(string path)
        {
            var components = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return TraversePath(this, components);
        }

        private Node TraversePath(Node node, IEnumerable<string> components)
        {
            var nextComponent = components.FirstOrDefault();

            if (nextComponent == null)
            {
                return node;
            }

            var childNode = node.GetChildNode(nextComponent);

            if (childNode != null)
            {
                return TraversePath(childNode, components.Skip(1));
            }

            throw new Exception("Not found");
        }

        public Node? GetChildNode(string? name)
        {
            return Children.FirstOrDefault(n => n.Name == name);
        }

        public async Task DeleteAsync()
        {
            Parent?.Children.Remove(this);

            await Context.SaveAsync();
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
