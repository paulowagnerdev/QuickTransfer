namespace Application.DTO.Results;

public class ResultT<T>
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public T? Data { get; private set; }

    protected ResultT(string message, T data)
    {
        IsSuccess = true;
        Message = message;
        Data = data;
    }

    protected ResultT(string message)
    {
        IsSuccess = false;
        Message = message;
    }

    public static ResultT<T> Success(T data, string message = "")
    {
        return new ResultT<T>(message, data);
    }
    public static ResultT<T> Failure(string message)
    {
        return new ResultT<T>(message);
    }
}