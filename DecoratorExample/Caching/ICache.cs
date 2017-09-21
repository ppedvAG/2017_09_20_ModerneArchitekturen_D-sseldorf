namespace DecoratorExample.Caching
{
    public interface ICache
    {
        bool Contains(string key);
        void Add<T>(string key, T value);
        T Get<T>(string key);
    }
}
