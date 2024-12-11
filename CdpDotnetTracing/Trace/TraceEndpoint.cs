namespace CdpDotnetTracing.Trace;

public static class TraceEndpoint
{
    public static void UseTraceEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("trace/end", Terminate);
        app.MapGet("trace", Trace);
    }
    
    
    private static IResult Terminate( ILogger<Program> logger)
    {
        logger.LogInformation("Trace endpoint called. Not calling anything else");
        return Results.Ok("Trace endpoint called");
    }
    
    private static async Task<IResult> Trace( ILogger<Program> logger, IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        var client = httpClientFactory.CreateClient();
        var url = config.GetValue<string>("NodeBackend");
        var response = await client.GetAsync(url + "/trace/end");
        logger.LogInformation("response status code {Status}", response.StatusCode);
        return Results.Ok("Trace endpoint called");
    }
}