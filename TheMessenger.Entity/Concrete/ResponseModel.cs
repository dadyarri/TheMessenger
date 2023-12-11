﻿namespace TheMessenger.Entity.Concrete;

public class ResponseModel : IResponseModel {
  public bool Success { get; set; }
  public string? Message { get; set; }
  public int StatusCode { get; set; }
}