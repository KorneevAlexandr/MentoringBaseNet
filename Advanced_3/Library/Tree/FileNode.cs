namespace Library.Tree
{
    public class FileNode : TreeNode
    {
        public FileNode(string name)
            : base(name)
        {
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
