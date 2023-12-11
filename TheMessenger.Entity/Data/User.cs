using System.ComponentModel.DataAnnotations;


namespace TheMessenger.Entity.Data;

public class User : BaseModel {
  [MaxLength(20)]
  public required string Username { get; set; }

  [MaxLength(200)]
  public string Bio { get; set; } = "";

  public required byte[] PasswordHash { get; set; }
  public required byte[] PasswordSalt { get; set; }
  public DateTime LastActive { get; set; }
}