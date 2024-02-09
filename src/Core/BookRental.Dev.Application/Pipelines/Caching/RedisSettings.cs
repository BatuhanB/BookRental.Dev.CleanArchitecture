namespace BookRental.Dev.Application.Pipelines.Caching;
public class RedisSettings
{
    public string Host { get; }
    public int Port { get; }
    public int ExpirationTime { get; }
    public int SlidingExpirationTime { get; }
}