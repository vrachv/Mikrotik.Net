namespace Mikrotik.Net.Api.Rest;

public abstract class MikrotikCommand
{
    public abstract string Path { get; }
    
    public abstract HttpMethod HttpMethod { get; }

    public virtual string? Content => null;

    public async Task<MikrotikResponse<TResponse>> ExecuteAsync<TResponse>(RestMikrotikConnection connection)
    {
        return await connection.SendAsync<TResponse>(HttpMethod, Path, Content);
    }

    public async Task<MikrotikResponse> ExecuteAsync(RestMikrotikConnection connection)
    {
        return await connection.SendAsync(HttpMethod, Path, Content);
    }

    public async void Execute(RestMikrotikConnection connection)
    {
        _ = await ExecuteAsync(connection);
    }
}