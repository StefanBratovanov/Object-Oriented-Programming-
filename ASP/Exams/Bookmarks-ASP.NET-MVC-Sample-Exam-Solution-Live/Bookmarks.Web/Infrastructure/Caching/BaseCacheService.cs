namespace Bookmarks.Web.Infrastructure.Caching
{
    using System;
    using System.Web;

    public abstract class BaseCacheService
    {
        protected T Get<T>(string cacheKey, Func<T> getItemcallback) where T : class
        {
            var items = HttpRuntime.Cache.Get(cacheKey) as T;
            if (items == null)
            {
                items = getItemcallback();
                HttpContext.Current.Cache.Insert(cacheKey, items);
                return items;
            }

            return items;
        }
    }
}