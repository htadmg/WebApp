using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

public class MiddlewareTempoExecucao
{
    private readonly RequestDelegate _next; 
    private readonly CronometroOptions _options;
    public MiddlewareTempoExecucao(RequestDelegate next, IOptions<CronometroOptions> options)
    {
        _next = next;
        _options = options.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Response.ContentType = "text/plain; charset=utf-8";
                var sw = Stopwatch.StartNew();
                await _next(context);
                sw.Stop(); 
                double tempo = 0;
                switch(_options.unidadeMedida)
                {
                    case UnidadesTempo.Nanossegundo:
                        double nanosPorTick = (1000.0 * 1000.0 * 1000.0) / Stopwatch.Frequency;
                        tempo = sw.ElapsedTicks * nanosPorTick;
                        break;

                    case UnidadesTempo.Microssegundo:
                        double microsPorTick = (1000.0 * 1000.0 * 1000.0) / Stopwatch.Frequency;
                        tempo = sw.ElapsedTicks * microsPorTick;
                        break;

                    case UnidadesTempo.Milissegundo:
                        double milisPorTick = (1000.0 * 1000.0 * 1000.0) / Stopwatch.Frequency;
                        tempo = sw.ElapsedTicks * milisPorTick;
                        break;
                }
                await context.Response.WriteAsync($"\nTempo de Execução (ms): (em milissegundos) :{sw.ElapsedMilliseconds}");   
                await context.Response.WriteAsync($"\nTempo de Execução (ms): (em {_options.unidadeMedida.ToString().ToLower() + 'S'}) : {tempo:f2}");   
    }
}