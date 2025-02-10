
namespace LibraryManagement.Redis
{
    public interface IRedisService
    {
        Task<T> GetKeyAsync<T>(string key);
        Task SetKeyAsync<T>(string key, T value, TimeSpan timeout);
    }
}