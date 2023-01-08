using FileCabinet.Caching;
using FileCabinet.Domain;
using FileCabinet.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace FileCabinet.Services
{
    public class DocumentService<T> : IDocumentService<T>
        where T : DocumentBase
    {
        private readonly IRepository<T> _repository;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        private readonly bool _isCacheable;
        private readonly string _cacheKey;

        public DocumentService(
            IRepository<T> repository,
            IMemoryCache memoryCache,
            IOptions<CachingOptions> cachingOptions)
        {
            _repository = repository;
            _memoryCache = memoryCache;
            var optionsValue = cachingOptions.Value;

            _cacheKey = $"{typeof(T).Name}_All";
            _isCacheable = optionsValue.IsCacheable<T>();
            _cacheOptions = new MemoryCacheEntryOptions();

            if (_isCacheable && !optionsValue.IsPermanentCacheable<T>())
            {
                _cacheOptions.SlidingExpiration =
                    TimeSpan.FromMinutes(optionsValue.GetCachingMinutes<T>());
            };
        }

        public IEnumerable<T> Search(string id = null, string title = null)
        {
            var query = GetAll();

            if (id is not null)
            {
                query = query.Where(x => x.Id.Contains(id));
            }

            if (title is not null)
            {
                query = query.Where(x => x.Title.Contains(title));
            }

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return GetAllOrCreate();
        }

        public T GetById(string id)
        {
            var entities = GetAllOrCreate();

            return entities.FirstOrDefault(x => x.Id == id);
        }

        public string Create(T entity)
        {
            entity.Id = _repository.Create(entity);

            if (_isCacheable)
            {
                var entities = GetAllOrCreate().ToList();
                entities.Add(entity);

                _memoryCache.Set(_cacheKey, entities, _cacheOptions);
            }

            return entity.Id;
        }

        public void Update(T entity)
        {
            _repository.Update(entity);

            if (_isCacheable)
            {
                _memoryCache.Remove(_cacheKey);

                GetAllOrCreate();
            }
        }

        public void Delete(string id)
        {
            Delete(GetById(id));
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);

            if (_isCacheable)
            {
                var entities = GetAllOrCreate();
                entities = entities.Where(x => !x.Id.Equals(entity.Id)).ToList();

                _memoryCache.Set(_cacheKey, entities, _cacheOptions);
            }
        }

        private IEnumerable<T> GetAllOrCreate()
        {
            IEnumerable<T> data;

            if (_isCacheable)
            {
                if (!_memoryCache.TryGetValue(_cacheKey, out data))
                {
                    data = _repository.GetAll();

                    _memoryCache.Set(_cacheKey, data, _cacheOptions);
                }
            }
            else
            {
                data = _repository.GetAll();
            }

            return data;
        }
    }
}
