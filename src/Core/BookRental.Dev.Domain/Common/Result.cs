namespace BookRental.Dev.Domain.Common;

public class Result<T>
{
    public Result()
    {
        Success = true;
    }
    public Result(string message)
    {
        Success = true;
        Message = message;
    }

    public Result(string message, bool success)
    {
        Success = success;
        Message = message;
    }
    public Result(T data, string message = null)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
}