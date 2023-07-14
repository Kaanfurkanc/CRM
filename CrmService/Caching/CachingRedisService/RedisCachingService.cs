using Caching.RedisCachingInterfaces;
using Core.GenericRepository;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Caching.CachingRedisService
{
    public class RedisCachingService<T> : IRedisCachingService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly IDistributedCache _distributedCache;
        public RedisCachingService(IGenericRepository<T> genericRepository, IDistributedCache distributedCache)
        {
            _genericRepository = genericRepository;
            _distributedCache = distributedCache;
        }
        public async Task AddToRedisCacheAsync(string key)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(2),
                SlidingExpiration = TimeSpan.FromSeconds(25)
            };

            var entities = await _genericRepository.GetAllAsync();
            string jsonEntities = JsonConvert.SerializeObject(entities);
            await _distributedCache.SetStringAsync(key, jsonEntities, options);
        }
        public async Task<IEnumerable<T>> GetAllFromRedisAsync(string key)
        {
            string? jsonEntities = await _distributedCache.GetStringAsync(key);

            if (jsonEntities == null)
            {
                return null; 
            }

            //var entities =  JsonSerializer.Deserialize<IEnumerable<T>>(jsonEntities);
            var entities = JsonConvert.DeserializeObject<List<T>>(jsonEntities);
            return entities.ToList();
        }
        public async Task RefreshAsync(string key)
        {
            await _distributedCache.RefreshAsync(key);
        }
        public async Task RemoveAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}
