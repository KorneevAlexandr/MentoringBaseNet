namespace FileCabinet.Caching
{
    public class CachingOptionItem
    {
        public string TypeName { get; set; }

        public bool IsCacheable { get; set; }

        public int CachingMinutes { get; set; }

        public bool IsPermanentCacheable { get; set; }
    }
}
