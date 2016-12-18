using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Spider.Helpers;
using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Cache
{
    public class RedisCacheService : ICacheService
    {
        private RedisCache cache;
        private static int DefaultCacheDuration => 60;

        public RedisCacheService()
        {
            //TODO: from settings
            cache = new RedisCache(new RedisCacheOptions() {
               Configuration = "localhost:6379",
            });
        }

        public void Store(string key, object content)
        {
            Store(key, content, DefaultCacheDuration);
        }

        public void Store(string key, object content, int duration)
        {
            string toStore;
            if (content is string)
            {
                toStore = (string)content;
            }
            else
            {
                toStore = JsonHelper.ToJson(content);
            }

            duration = duration <= 0 ? DefaultCacheDuration : duration;
            cache.Set(key, Encoding.UTF8.GetBytes(toStore), new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromSeconds(duration)
            });
        }

        public T Get<T>(string key) where T : class
        {
            var fromCache = cache.Get(key);
            if (fromCache == null)
            {
                return null;
            }
         
            var str = Encoding.UTF8.GetString(fromCache);
            if (typeof(T) == typeof(string))
            {
                return str as T;
            }
            return JsonHelper.FromJson<T>(str);
        }
    }
}
