using Microsoft.AspNetCore.Builder;

public static class MetodosExtensao
{
    public static IApplicationBuilder UseTempoExecucao(this IApplicationBuilder app)
    {
        app.UseMiddleware<MiddlewareTempoExecucao>();
        return app;
    }
}