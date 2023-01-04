using FileCabinet.Console.ConsoleComponents.DocumentComponents;
using FileCabinet.Domain;

namespace FileCabinet.Console.ConsoleComponents
{
    internal class Menu : IMenu
    {
        private readonly IDocumentComponent<Patent> _patentComponent;
        private readonly IIsbnDocumentComponent<Book> _bookComponent;
        private readonly IIsbnDocumentComponent<LocalBook> _localBookComponent;

        public Menu(
            IDocumentComponent<Patent> patentComponent,
            IIsbnDocumentComponent<Book> bookComponent,
            IIsbnDocumentComponent<LocalBook> localBookComponent)
        {
            _patentComponent = patentComponent;
            _bookComponent = bookComponent;
            _localBookComponent = localBookComponent;
        }

        public void Show()
        {
            var userAction = string.Empty;

            while (userAction != "4")
            {
                userAction = SelectionMenu();

                switch (userAction)
                {
                    case "1":
                        _patentComponent.Show();
                        break;
                    case "2":
                        _bookComponent.Show();
                        break;
                    case "3":
                        _localBookComponent.Show();
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            }

            System.Console.WriteLine("\nGood buy!");
        }

        private string SelectionMenu()
        {
            System.Console.WriteLine("\n\t*** GENERAL MENU ***");
            System.Console.WriteLine("1) Patents");
            System.Console.WriteLine("2) Books");
            System.Console.WriteLine("3) Localazed books");
            System.Console.WriteLine("4) Exit");
            System.Console.Write("\n> ");

            return System.Console.ReadLine();
        }
    }
}
