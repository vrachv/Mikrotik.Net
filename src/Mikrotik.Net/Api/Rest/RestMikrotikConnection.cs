using System.Net;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;

namespace Mikrotik.Net.Api.Rest;

public sealed class RestMikrotikConnection : IRestMikrotikConnection
{
    private static readonly JsonSerializer Serializer = new();
    
    private readonly HttpClientHandler _httpClientHandler;
    
    private readonly HttpClient _httpClient;

    public RestMikrotikConnection(
        Uri uri,
        string login,
        string password,
        int timeoutSec = 30,
        bool ignoreCertificate = false,
        X509Certificate? certificate = null,
        bool debug = false)
    {
        IgnoreCertificate = ignoreCertificate;
        Debug = debug;
        
        _httpClientHandler = new HttpClientHandler();

        if (certificate != null)
        {
            _httpClientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            _httpClientHandler.ClientCertificates.Add(certificate);
        }
        
        _httpClientHandler.ServerCertificateCustomValidationCallback += ServerCertificateCustomValidationCallback;
        _httpClient = new HttpClient(_httpClientHandler)
        {
            BaseAddress = new Uri(uri, "rest/"),
            Timeout = TimeSpan.FromSeconds(timeoutSec),
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{login}:{password}"))),
                Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
            }
        };
    }
    
    public bool IgnoreCertificate { get; set; }
    
    public bool Debug { get; set; }

    public int GlobalTimeout
    {
        get => _httpClient.Timeout.Seconds;
        set => _httpClient.Timeout = TimeSpan.FromSeconds(value);
    }

    public async Task<MikrotikResponse<T>> SendAsync<T>(HttpMethod method, string request, string? content = null,
        CancellationToken cancellationToken = default)
    {
        var hrm = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(request, UriKind.Relative),
            Content = content == null ? null : new StringContent(content, Encoding.Default, "application/json")
        };

        var response = await _httpClient.SendAsync(hrm, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        if (Debug)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Request: " + method + ' ' + response.RequestMessage.RequestUri);
            Console.WriteLine("Status code: " + response.StatusCode);
            Console.WriteLine("-------------------------------------");
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            // todo
        }

        var str = await response.Content.ReadAsStringAsync();
        return new MikrotikResponse<T>(str);
    }

    public async Task<MikrotikResponse> SendAsync(HttpMethod method, string request, string? content = null,
        CancellationToken cancellationToken = default)
    {
        var hrm = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(request, UriKind.Relative),
            Content = content == null ? null : new StringContent(content, Encoding.Default, "application/json")
        };

        var response = await _httpClient.SendAsync(hrm, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        if (Debug)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Request: " + method + ' ' + response.RequestMessage.RequestUri);
            Console.WriteLine("Status code: " + response.StatusCode);
            Console.WriteLine("-------------------------------------");
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            // todo
        }

        var str = await response.Content.ReadAsStringAsync();
        return new MikrotikResponse(str);
    }

    private bool ServerCertificateCustomValidationCallback(
        HttpRequestMessage requestMessage,
        X509Certificate2 certificate,
        X509Chain chain,
        SslPolicyErrors errors)
    {
        if (IgnoreCertificate)
        {
            return true;
        }

        return errors == SslPolicyErrors.None;
    }

    #region Dispose

    public void Dispose()
    {
        _httpClientHandler.ServerCertificateCustomValidationCallback -= ServerCertificateCustomValidationCallback;
        _httpClientHandler.Dispose();
        _httpClient.Dispose();
    }

    #endregion Dispose
}