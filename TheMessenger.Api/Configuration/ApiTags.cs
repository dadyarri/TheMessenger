namespace TheMessenger.Api.Configuration;

public record ApiTag(string Name, string Description);

public class ApiTags {
  public static readonly ApiTag Messages = new("Messages", "API methods related to messages");
  public static readonly ApiTag Users = new("Users", "API methods related to users");
  public static readonly ApiTag Other = new("Other", "API methods, that can't be related to any other category");
}