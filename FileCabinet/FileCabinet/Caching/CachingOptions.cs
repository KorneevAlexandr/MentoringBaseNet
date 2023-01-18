namespace FileCabinet.Caching
{
    public class CachingOptions
    {
        public IEnumerable<CachingOptionItem> OptionItems { get; set; }

        public int GetCachingMinutes<T>()
        {
            var optionItem = GetOptionItem<T>();

            return optionItem.CachingMinutes;
        }

        public bool IsCacheable<T>()
        {
            var optionItem = GetOptionItem<T>();

            return optionItem.IsCacheable;
        }

        public bool IsPermanentCacheable<T>()
        {
            var optionItem = GetOptionItem<T>();

            return optionItem.IsPermanentCacheable;
        }

        private CachingOptionItem? GetOptionItem<T>() =>
            OptionItems.FirstOrDefault(x => x.TypeName.Equals(typeof(T).Name));
    }
}
