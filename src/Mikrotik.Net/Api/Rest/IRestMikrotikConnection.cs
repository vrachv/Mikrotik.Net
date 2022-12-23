namespace Mikrotik.Net.Api.Rest;

public interface IRestMikrotikConnection : IDisposable
{
    bool IgnoreCertificate { get; set; }
    
    int GlobalTimeout { get; set; }

    Task<MikrotikResponse<T>> SendAsync<T>(HttpMethod method, string request, string? content = null,
        CancellationToken cancellationToken = default);

    Task<MikrotikResponse> SendAsync(HttpMethod method, string request, string? content = null,
        CancellationToken cancellationToken = default);
}