using Library;
using Library.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FileSystemVisitor visitor = new FileSystemVisitor("C:\\Users\\Aliaksandr_Karneyeu\\source\\CryptoJack");
            var tree = visitor.GetTree();

            var view = new TreeView();
            var root = new TreeViewItem() { Header = "C:\\Users\\Aliaksandr_Karneyeu\\source\\CryptoJack" };

            FillTree(tree, root);
            view.Items.Add(root);

            MainGrid.Children.Add(view);
        }

        private void FillTree(TreeNode startNode, TreeViewItem root)
        {
            var allItems = startNode.GetChildren();
            var directories = allItems.Where(x => x.IsComposite());
            var files = allItems.Where(x => !x.IsComposite());

            foreach (var directory in directories)
            {
                var node = new TreeViewItem() { Header = directory.ToString() };
                root.Items.Add(node);
                FillTree(directory, node);
            }

            foreach (var file in files)
            {
                root.Items.Add(new TreeViewItem() { Header = file.ToString() });
            }
        }
    }
}
