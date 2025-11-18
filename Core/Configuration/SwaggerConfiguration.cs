using Microsoft.OpenApi.Models;

namespace TokenJwt.Core;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "JWT Authentication API",
                            Version = "v1.0",
                            Description = GetSwaggerDocDescription(),
                            Contact = new OpenApiContact
                            {
                                Name = "Douglas Damasceno",
                                Email = "douglasddx@gmail.com",
                                Url = new Uri("https://github.com/douglasddamasceno/")
                            },
                            License = new OpenApiLicense
                            {
                                Name = "MIT License",
                                Url = new Uri("https://opensource.org/licenses/MIT")
                            }
                        }
                    );

                    // Configuração de segurança JWT
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = GetSwaggerSecuryDescription()
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
                    });

                    // Agrupa endpoints por tags
                    c.TagActionsBy(api => new[] { api.GroupName ?? "Default" });
                    c.DocInclusionPredicate((name, api) => true);

                    // Ordena as ações alfabeticamente
                    c.OrderActionsBy(api => api.RelativePath);
                });
    }

    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT API v1");
            c.RoutePrefix = string.Empty;

            c.DocumentTitle = "JWT API - Documentação";
            c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
            c.DefaultModelsExpandDepth(-1);
            c.DisplayRequestDuration();

            c.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
            {
                ["theme"] = "monokai"
            };
        });
    }

    private static string GetSwaggerDocDescription()
    {
        return """
                ## API de Autenticação JWT
                Esta API demonstra a implementação de autenticação e autorização usando JSON Web Tokens (JWT).

                ### Funcionalidades:
                - 🔐 Autenticação via JWT
                - 👥 Controle de acesso baseado em roles (Admin/User)
                - 📝 Endpoints protegidos por autorização

                ### Como usar:
                1. Faça logon através do endpoint `/login`
                2. Copie o token retornado
                3. Clique no botão **Authorize**
                4. Cole o token no formato: `Bearer token-aqui`
                5. Teste os endpoints protegidos

                ### Roles disponíveis:
                - **admin**: Acesso total
                - **user**: Acesso limitado
                """;
    }

    private static string GetSwaggerSecuryDescription()
    {
        return """
                Insira o token no seguinte formato:
                `Bearer seu-token-aqui`
                """;
    }
}