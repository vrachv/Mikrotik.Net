using Newtonsoft.Json;

namespace Mikrotik.Net;

public class MikrotikResponse
{
    public readonly string Response;

    public MikrotikResponse(string response)
    {
        Response = response;
    }
}

public class MikrotikResponse<T> : MikrotikResponse
{
    public MikrotikResponse(string response) : base(response)
    { }

    public T? Deserialize()
    {
        return JsonConvert.DeserializeObject<T>(Response);
    }
}