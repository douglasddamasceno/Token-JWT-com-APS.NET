
using Microsoft.AspNetCore.Mvc;

namespace Auth;

public static class LoginEndpoint
{
    public static void MapLoginEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/login", ([FromBody] LoginRequest req, IConfiguration config, JwtService jwt) =>
        {
            var users = config.GetSection("Users").Get<List<UserModel>>()!;

            var user = users.FirstOrDefault(u =>
                u.Username == req.Username &&
                u.Password == req.Password);

            if (user == null)
                return Results.Unauthorized();

            var token = jwt.GenerateToken(user);

            return Results.Ok(new
            {
                token,
                role = user.Role,
                user = user.Username
            });
        });
    }
}