using System;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Cache;

namespace Sample.iOS
{
    public class ImageServiceEx:IImageServiceEx
    {
        public async Task ForceInvalidateCacheEntryAsync(string key, CacheType cacheType, bool removeSimilar = false)
        {
            await FFImageLoading.ImageService.Instance.InvalidateCacheEntryAsync(key, cacheType, removeSimilar);
        }
    }
}
