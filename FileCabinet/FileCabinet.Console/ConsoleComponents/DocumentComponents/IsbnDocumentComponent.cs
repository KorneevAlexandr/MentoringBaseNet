using FileCabinet.Console.ConsoleComponents.DocumentFormatters;
using FileCabinet.Console.Extensions;
using FileCabinet.Domain;
using FileCabinet.Services;

namespace FileCabinet.Console.ConsoleComponents.DocumentComponents
{
    public class IsbnDocumentComponent<T> : DocumentComponent<T>, IIsbnDocumentComponent<T>
        where T : DocumentBase, IIsbn
    {
        private readonly IIsbnDocumentService<T> _isbnDocumentService;

        public IsbnDocumentComponent(
            IDocumentService<T> documentService, 
            IDocumentFormatter<T> documentFormatter,
            IIsbnDocumentService<T> isbnDocumentService) 
            : base(documentService, documentFormatter)
        {
            _isbnDocumentService = isbnDocumentService;
        }

        public override void Show()
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
                        DefaultSearch();
                        break;
                    case "3":
                        IsbnSearch();
                        break;
                    case "4":
                        CreateDocument();
                        break;
                    case "5":
                        DeleteDocument();
                        break;
                    case "6":
                        break;
                    default:
                        break;
                }
            }
        }

        protected virtual string SelectionMenu()
        {
            System.Console.WriteLine("\n\t*** Menu ***");
            System.Console.WriteLine("1) Show all documents");
            System.Console.WriteLine("2) Search documents by number or title");
            System.Console.WriteLine("3) Search documents by ISBN");
            System.Console.WriteLine("4) Create document");
            System.Console.WriteLine("5) Delete document");
            System.Console.WriteLine("6) Back to general menu");
            System.Console.Write("\n> ");

            return System.Console.ReadLine();
        }

        private void IsbnSearch()
        {
            System.Console.Write("Enter document number (or skip): ");
            var documentNumber = System.Console.ReadLine();

            System.Console.Write("Enter document title (or skip): ");
            var documentTitle = System.Console.ReadLine();

            System.Console.Write("Enter document ISBN (or skip): ");
            var documentIsbn = System.Console.ReadLine();

            var documents = _isbnDocumentService.Search(documentNumber, documentTitle, documentIsbn);
            documents.Show(_documentFormatter);
        }
    }
}
