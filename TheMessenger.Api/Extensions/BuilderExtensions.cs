using System.Reflection;

using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using NSwag.Generation.AspNetCore;

using TheMessenger.Api.Configuration;
using TheMessenger.Api.Data;


namespace TheMessenger.Api.Extensions;

public static class BuilderExtensions {
  public static void ConfigureFastEndpoints(this WebApplicationBuilder builder) {
    var signingKey = builder
      .Configuration
      .GetRequiredSection("Security")
      .GetRequiredSection("SigningKey").Value;

    ArgumentNullException.ThrowIfNull(signingKey);

    builder.Services.AddAuthorization();
    builder.Services.AddFastEndpoints();
    builder.Services.AddJWTBearerAuth(signingKey);
  }

  public static void ConfigureDatabase(this WebApplicationBuilder builder) {
    builder.Services.AddDbContextPool<AppDbContext>(
      options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
  }

  public static void MapConfiguration(this WebApplicationBuilder builder) {
    builder.Services.Configure<SecurityConfiguration>(builder.Configuration.GetRequiredSection("Security"));
    builder.Services.AddSingleton(resolver =>
      resolver.GetRequiredService<IOptions<SecurityConfiguration>>().Value);
  }

  public static void RegisterDependencies(this WebApplicationBuilder builder) { }

  public static void ConfigureSwaggerDocuments(this WebApplicationBuilder builder) {
    builder.Services.SwaggerDocument(o => {
      o.AutoTagPathSegmentIndex = 0;
      o.MaxEndpointVersion = 2;
      o.ShortSchemaNames = true;
      o.ShowDeprecatedOps = true;
      o.TagDescriptions = Tags;
      o.DocumentSettings = s => DocumentSettings(s, "v1");
    });
    return;

    void DocumentSettings(AspNetCoreOpenApiDocumentGeneratorSettings s, string version) {
      s.Title = "TheMessenger API";
      s.Description = "API of the real-time messenger";
      s.DocumentName = $"TheMessenger {version}";
      s.Version = version;
    }

    void Tags(Dictionary<string, string> t) {
      foreach (var prop in typeof(ApiTags).GetFields(BindingFlags.Static)) {
        var value = (ApiTag)prop.GetValue(null)!;
        t[value.Name] = value.Description;
      }
    }
  }
}