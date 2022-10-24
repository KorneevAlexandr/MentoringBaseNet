using Library.Tree;

namespace Library
{
    public class FileSystemVisitor
    {
        private readonly string _startDirectory;
        
        private TreeNode _root;

        public FileSystemVisitor(string startDirectory)
        {
            _startDirectory = startDirectory;
            _root = new DirectoryNode(GetNameWithoutPath(startDirectory));
        }

        public TreeNode GetTree()
        {
            FillTree(_startDirectory, _root);
            return _root;
        }

        private void FillTree(string startDirecory, TreeNode root)
        {
            var directories = Directory.GetDirectories(startDirecory);
            var files = Directory.GetFiles(startDirecory);

            foreach (var directory in directories)
            {
                var node = new DirectoryNode(GetNameWithoutPath(directory));
                root.Add(node);
                FillTree(directory, node);
            }

            foreach (var file in files)
            {
                root.Add(new FileNode(GetNameWithoutPath(file)));
            }
        }

        private string GetNameWithoutPath(string path)
        {
            var lastPathIndex = path.LastIndexOf(@"\");
            return path.Substring(++lastPathIndex);
        }
    }
}