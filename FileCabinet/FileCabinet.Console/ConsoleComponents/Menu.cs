using FileCabinet.Console.Extensions;
using FileCabinet.Domain;
using FileCabinet.Services;
using static FileCabinet.Console.ConsoleComponents.EntityEnterHelper;

namespace FileCabinet.Console.ConsoleComponents
{
    internal class Menu : IMenu
    {
        private readonly IIsbnDocumentService<Book> _bookService;
        private readonly IIsbnDocumentService<LocalBook> _localBookService;
        private readonly IDocumentService<Patent> _patentService;

        public Menu(
            IIsbnDocumentService<Book> bookService, 
            IIsbnDocumentService<LocalBook> localBookService, 
            IDocumentService<Patent> patentService)
        {
            _bookService = bookService;
            _localBookService = localBookService;
            _patentService = patentService;
        }

        public void Show()
        {
            var userAction = string.Empty;

            while (userAction != "6")
            {
                userAction = SelectionMenu();

                switch (userAction)
                {
                    case "1":
                        ShowAllDocuments();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        CreateDocument();
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }

            System.Console.WriteLine("\nGood buy!");
        }

        private string SelectionMenu()
        {
            System.Console.WriteLine("\n\t*** MENU ***");
            System.Console.WriteLine("1) Show all documents");
            System.Console.WriteLine("2) Search documents by number or title");
            System.Console.WriteLine("3) Search ISBN documents");
            System.Console.WriteLine("4) Create document");
            System.Console.WriteLine("5) Delete document");
            System.Console.WriteLine("6) Exit");
            System.Console.Write("\n> ");

            return System.Console.ReadLine();
        }

        private DocumentTypes SelectType()
        {
            var userAction = string.Empty;

            while (userAction.NotIn("1", "2", "3"))
            {
                System.Console.WriteLine("Select document type: ");
                System.Console.WriteLine("1) - Book");
                System.Console.WriteLine("2) - Local book");
                System.Console.WriteLine("3) - Patent");

                userAction = ReadAsStringValue("");
            }

            return userAction switch
            {
                "1" => DocumentTypes.Book,
                "2" => DocumentTypes.LocalBook,
                "3" => DocumentTypes.Patent,
                _ => throw new ArgumentException("You select non existend value."),
            };
        }

        private void ShowAllDocuments()
        {
            var documentType = SelectType();

            switch (documentType)
            {
                case DocumentTypes.Book:
                    _bookService.GetAll().Show();
                    break;
                case DocumentTypes.LocalBook:
                    _localBookService.GetAll().Show();
                    break;
                case DocumentTypes.Patent:
                    _patentService.GetAll().Show();
                    break;
            }
        }

        private void CreateDocument()
        {
            var documentType = SelectType();

            switch (documentType)
            {
                case DocumentTypes.Book:
                    _bookService.Create(EnterBook());
                    break;
                case DocumentTypes.LocalBook:
                    _localBookService.Create(EnterLocalBook());
                    break;
                case DocumentTypes.Patent:
                    _patentService.Create(EnterPatent());
                    break;
            }

            System.Console.WriteLine("Document created successfully");
        }
    }
}
