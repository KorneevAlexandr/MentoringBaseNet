using System.Windows;
using Task2;

namespace Task1_WPF
{
    public partial class MainWindow : Window
    {
        private readonly IHelloFormatter _helloFormatter;

        public MainWindow()
        {
            InitializeComponent();

            _helloFormatter = new HelloFormatter();
        }

        private void NameBtn_Click(object sender, RoutedEventArgs e)
        {
            var userName = NameTextBox.Text;

            var defaultHello = $"Hello, {userName}!";
            var formatHello = _helloFormatter.Hello(userName);

            ResultLabel.Content = $"{defaultHello}\n{formatHello}";
        }
    }
}
