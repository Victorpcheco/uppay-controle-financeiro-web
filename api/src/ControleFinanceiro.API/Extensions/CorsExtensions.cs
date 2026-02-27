namespace ControleFinanceiro.API.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("PoliticaRestritiva", policy =>
            {
                policy.WithOrigins(
                        "http://localhost:3000",
                        "https://localhost:3000",
                        "http://localhost:4200",
                        "https://localhost:4200",
                        "https://localhost:5173",
                        "https://meuapp.com.br",
                        "https://www.meuapp.com.br"
                    )
                    .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH")
                    .WithHeaders("Content-Type", "Authorization", "Accept", "X-Requested-With")
                    .AllowCredentials();
            });

            options.AddPolicy("PoliticaDesenvolvimento", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }

    public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseCors("PoliticaDesenvolvimento");
        else
            app.UseCors("PoliticaRestritiva");

        return app;
    }
}
