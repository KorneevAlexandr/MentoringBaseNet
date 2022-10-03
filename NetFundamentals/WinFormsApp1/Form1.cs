using Task2;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NameBtn_Click(object sender, EventArgs e)
        {
            var userName = NameTextBox.Text;
            var helloFormatter = new HelloFormatter(userName);

            var defaultHello = $"Hello, {userName}!";
            var formatHello = helloFormatter.Hello();

            ResultLabel.Text = $"{defaultHello}\n{formatHello}";
        }
    }
}