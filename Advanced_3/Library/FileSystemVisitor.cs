using Library.Tree;

namespace Library
{
    public class FileSystemVisitor
    {
        private readonly string _startDirectory;
        private readonly Func<IEnumerable<FileSystemInfo>, IEnumerable<FileSystemInfo>> _sortedFunc;

        private TreeNode _root;

        public FileSystemVisitor(string startDirectory)
        {
            _startDirectory = startDirectory;
            _root = new DirectoryNode(GetNameWithoutPath(startDirectory));
        }

        public FileSystemVisitor(
            string startDirectory, 
            Func<IEnumerable<FileSystemInfo>, IEnumerable<FileSystemInfo>> sortedFunc)
            : this (startDirectory)
        {
            _sortedFunc = sortedFunc;
        }

        public TreeNode GetTree()
        {
            FillTree(_startDirectory, _root);
            return _root;
        }

        private void FillTree(string startDirecory, TreeNode root)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(startDirecory);
            var directories = _sortedFunc == null ? dirInfo.GetDirectories() : _sortedFunc(dirInfo.GetDirectories());
            var files = _sortedFunc == null ? dirInfo.GetFiles() : _sortedFunc(dirInfo.GetFiles());

            foreach (var directory in directories)
            {
                var node = new DirectoryNode(GetNameWithoutPath(directory.FullName));
                root.Add(node);
                FillTree(directory.FullName, node);
            }

            foreach (var file in files)
            {
                root.Add(new FileNode(GetNameWithoutPath(file.FullName)));
            }

            files = null;
        }

        private string GetNameWithoutPath(string path)
        {
            var lastPathIndex = path.LastIndexOf(@"\");
            return path.Substring(++lastPathIndex);
        }
    }
}