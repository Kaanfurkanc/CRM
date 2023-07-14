using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching.RedisCachingInterfaces
{
    public interface IRedisCachingService<T> 
    {
        Task AddToRedisCacheAsync(string key);
        Task<IEnumerable<T>> GetAllFromRedisAsync(string key);
        Task RemoveAsync(string key);
        Task RefreshAsync(string key);
    }
}