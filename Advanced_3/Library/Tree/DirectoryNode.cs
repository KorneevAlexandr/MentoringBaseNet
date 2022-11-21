namespace Library.Tree
{
    public class DirectoryNode : TreeNode
    {
        private readonly List<TreeNode> _nodes = new List<TreeNode>();

        public DirectoryNode(string name)
            : base(name)
        {
        }

        public override void Add(TreeNode node)
        {
            _nodes.Add(node);
        }

        public override IEnumerable<TreeNode> GetChildren()
        {
            return _nodes;
        }

        public override bool IsComposite()
        {
            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
