using Task2;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly IHelloFormatter _helloFormatter;

        public Form1()
        {
            InitializeComponent();

            _helloFormatter = new HelloFormatter();
        }

        private void NameBtn_Click(object sender, EventArgs e)
        {
            var userName = NameTextBox.Text;

            var defaultHello = $"Hello, {userName}!";
            var formatHello = _helloFormatter.Hello(userName);

            ResultLabel.Text = $"{defaultHello}\n{formatHello}";
        }
    }
}