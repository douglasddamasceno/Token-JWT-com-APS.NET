namespace Feature;

public static class AdminEndpoint
{
    public static void MapAdminEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/admin", () => "Bem-vindo, administrador!")
           .RequireAuthorization("AdminPolicy");
    }
}