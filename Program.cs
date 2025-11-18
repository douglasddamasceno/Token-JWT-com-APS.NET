using Auth;
using Feature;
using TokenJwt.Core;
using TokenJwt.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSingleton<JwtService>();
builder.Services.AddJwtConfiguration(builder.Configuration);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
// app.UseHttpsRedirection();
app.UseSwaggerConfiguration();
app.MapLoginEndpoints();
app.MapAdminEndpoints();
app.MapUserEndpoints();
app.Run();