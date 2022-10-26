namespace Library.Tree
{
    public abstract class TreeNode
    {
        public TreeNode(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void Add(TreeNode node)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TreeNode> GetChildren()
        {
            throw new NotImplementedException();
        }

        public abstract bool IsComposite();

        public override string ToString()
        {
            return Name;
        }
    }
}
