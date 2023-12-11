using JetBrains.Annotations;


namespace TheMessenger.Entity.Response;

public sealed class Result<T> where T : class {
  public bool IsSuccess { [UsedImplicitly] get; private init; }
  public T? Data { [UsedImplicitly] get; private init; }

  public static Result<T> Success(T data) {
    return new Result<T> {
      IsSuccess = true,
      Data = data,
    };
  }

  public static Result<T> Failure(T data) {
    return new Result<T> {
      IsSuccess = false,
      Data = data,
    };
  }
}