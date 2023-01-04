using Newtonsoft.Json;

namespace FileCabinet.Domain
{
    public abstract class DocumentBase
    {
        public DocumentBase(string documentType)
        {
            Type = documentType;
        }

        [JsonIgnore]
        public string Type { get; private set; }

        public string Id { get; set; }

        public string Title { get; set; }
    }
}
