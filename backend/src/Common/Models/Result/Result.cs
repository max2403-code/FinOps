namespace Common.Models.Result;

public readonly record struct Result
{
    public bool IsSuccess { get; init; }

    public ResultError? Error { get; init; }

    private Result(bool isSuccess, ResultError? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(ResultError error) => new(false, error);
    public static Result Failure(string message) => new(false, new ResultError(message));

    public static implicit operator Result(bool success) => success ? Success() : Failure("Operation failed");
    public static implicit operator Result(ResultError error) => Failure(error);

}

public readonly record struct Result<T>
{
    public bool IsSuccess { get; init; }

    public T? Value { get; init; }
    
    public ResultError? Error { get; init; }
     
    private Result(T? value, ResultError? error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }

    public static Result<T> Success(T value) => new(value, null, true);
    public static Result<T> Failure(ResultError error) => new(default, error, false);

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(ResultError error) => Failure(error);
}
