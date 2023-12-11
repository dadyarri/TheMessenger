using FastEndpoints;

using FluentResults;

using TheMessenger.Api.Configuration;


namespace TheMessenger.Api.Endpoints;

public class Ping : Endpoint<EmptyRequest, Result<string>> {
  public override async Task<Result<string>> ExecuteAsync(EmptyRequest req, CancellationToken ct) {
    return Result.Ok("pong");
  }

  public override void Configure() {
    Get("/ping");
    Summary(s => {
      s.Summary = "Always returns pong";
      s.Description = AllowedScopes.Anyone;
    });
    Options(o => o.WithTags(ApiTags.Other.Name));
    AllowAnonymous();
  }
}