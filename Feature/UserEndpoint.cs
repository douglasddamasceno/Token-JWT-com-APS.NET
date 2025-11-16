namespace Feature;

public static class UserEndpoint
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/user", () => "Olá, usuário autenticado.")
           .RequireAuthorization("UserPolicy");
    }
}
