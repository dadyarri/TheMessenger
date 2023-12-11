namespace TheMessenger.Entity.Concrete;

public interface IResponseDataModel<T> : IResponseModel {
  public T Data { get; set; }
}