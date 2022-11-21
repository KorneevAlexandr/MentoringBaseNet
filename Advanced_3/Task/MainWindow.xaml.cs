using Library;
using Library.Tree;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string AppSettingsFile = "appsettings.json";

        private string _baseDirectory;
        private FileSystemVisitor _visitor;

        private delegate void Handler(string message);
        private event Handler HandlerEvent; 

        public MainWindow()
        {
            InitializeComponent();

            var settingsData = File.ReadAllText(AppSettingsFile);
            var settings = JsonConvert.DeserializeObject<Settings>(settingsData);
            _baseDirectory = settings.BaseDirectory;

            HandlerEvent += ShowMessage;
        }

        private void FillTree()
        {
            var tree = _visitor.GetTree();
            var root = new TreeViewItem() { Header = _baseDirectory };
            Tree.Items.Clear();

            FillTreeImpl(tree, root);
            Tree.Items.Add(root);
        }

        private void FillTreeImpl(TreeNode startNode, TreeViewItem root)
        {
            var allItems = startNode.GetChildren();
            var directories = allItems.Where(x => x.IsComposite());
            var files = allItems.Where(x => !x.IsComposite());

            foreach (var directory in directories)
            {
                var node = new TreeViewItem() { Header = directory.ToString() };
                root.Items.Add(node);
                FillTreeImpl(directory, node);
            }

            foreach (var file in files)
            {
                root.Items.Add(new TreeViewItem() { Header = file.ToString() });
            }
        }

        private void ShowMessage(string message)
        {
            Log.Text = message;
        }

        private void OrderName_Click(object sender, RoutedEventArgs e)
        {
            _visitor = new FileSystemVisitor(_baseDirectory);
            FillTree();
            HandlerEvent?.Invoke("Files found");
        }

        private void OrderDescName_Click(object sender, RoutedEventArgs e)
        {
            var sortedFunc = (IEnumerable<FileSystemInfo> source) => source.OrderByDescending(x => x.Name);
            _visitor = new FileSystemVisitor(_baseDirectory, sortedFunc);
            FillTree();
            HandlerEvent?.Invoke("Filtered file found");
        }

        private void OrderDateBtn_Click(object sender, RoutedEventArgs e)
        {
            var sortedFunc = (IEnumerable<FileSystemInfo> source) => source.OrderBy(x => x.CreationTime);
            _visitor = new FileSystemVisitor(_baseDirectory, sortedFunc);
            FillTree();
            HandlerEvent?.Invoke("Filtered file (by date) found");
        }
    }
}
