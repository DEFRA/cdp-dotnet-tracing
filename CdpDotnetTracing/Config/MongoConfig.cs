namespace CdpDotnetTracing.Config;

public class MongoConfig
{
    public string DatabaseUri { get; init; } = default!;
    public string DatabaseName { get; init; } = default!;
}