using System;
using System.Collections.Generic;
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
using Task2;

namespace Task1_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NameBtn_Click(object sender, RoutedEventArgs e)
        {
            var userName = NameTextBox.Text;
            var helloFormatter = new HelloFormatter(userName);

            var defaultHello = $"Hello, {userName}!";
            var formatHello = helloFormatter.Hello();

            ResultLabel.Content = $"{defaultHello}\n{formatHello}";
        }
    }
}
