#nullable enable


namespace FileViewer.Services
{
    public sealed class RootNode : Node
    {
        private const string RootDisplayName = "Root";
        private readonly NodeContext nodeContext;

        internal RootNode(NodeContext nodeContext)
            : base(null, string.Empty)
        {
            this.nodeContext = nodeContext;
        }

        public override string GetDisplayName()
        {
            return RootDisplayName;
        }

        protected override NodeContext Context => nodeContext;
    }
}
