using FileCabinet.Console.ConsoleComponents.DocumentFormatters;
using FileCabinet.Console.Extensions;
using FileCabinet.Domain;
using FileCabinet.Services;
using static FileCabinet.Console.ConsoleComponents.ConsoleHelper;

namespace FileCabinet.Console.ConsoleComponents.DocumentComponents
{
    public class DocumentComponent<T> : IDocumentComponent<T>
        where T : DocumentBase
    {
        protected readonly IDocumentService<T> _documentService;
        protected readonly IDocumentFormatter<T> _documentFormatter;

        public DocumentComponent(IDocumentService<T> documentService, IDocumentFormatter<T> documentFormatter)
        {
            _documentService = documentService;
            _documentFormatter = documentFormatter;
        }

        public virtual void Show()
        {
            var userAction = string.Empty;

            while (userAction != "5")
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
                        CreateDocument();
                        break;
                    case "4":
                        DeleteDocument();
                        break;
                    default:
                        break;
                }
            }
        }

        protected virtual string SelectionMenu()
        {
            System.Console.WriteLine("\n\t*** MENU ***");
            System.Console.WriteLine("1) Show all documents");
            System.Console.WriteLine("2) Search documents by number or title");
            System.Console.WriteLine("3) Create document");
            System.Console.WriteLine("4) Delete document");
            System.Console.WriteLine("5) Back to general menu");
            System.Console.Write("\n> ");

            return System.Console.ReadLine();
        }

        protected void ShowAllDocuments()
        {
            _documentService.GetAll().Show(_documentFormatter);
        }

        protected void DefaultSearch()
        {
            System.Console.Write("Enter document number (or skip): ");
            var documentNumber = System.Console.ReadLine();

            System.Console.Write("Enter document title (or skip): ");
            var documentTitle = System.Console.ReadLine();

            var documents = _documentService.Search(documentNumber, documentTitle);
            documents.Show(_documentFormatter);
        }

        protected void CreateDocument()
        {
            var document = _documentFormatter.Read();
            _documentService.Create(document);
        }

        protected void DeleteDocument()
        {
            var documentNumber = ReadAsStringValue("Enter document number for deleting: ");
            _documentService.Delete(documentNumber);
        }
    }
}
