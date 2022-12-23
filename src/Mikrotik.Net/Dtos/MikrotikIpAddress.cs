using Newtonsoft.Json;

namespace Mikrotik.Net.Dtos;

public class MikrotikIpAddress
{
    [JsonProperty(".id")]
    public string Id { get; set; }

    [JsonProperty("actual-interface")]
    public string ActualInterface { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("comment")]
    public string Comment { get; set; }

    [JsonProperty("disabled")]
    internal string DisabledStr { get; set; }

    [JsonProperty("dynamic")]
    internal string DynamicStr { get; set; }

    [JsonProperty("interface")]
    public string Interface { get; set; }

    [JsonProperty("invalid")]
    internal string InvalidStr { get; set; }

    [JsonProperty("network")]
    public string Network { get; set; }
    
    public bool Invalid => InvalidStr == "true";
    
    public bool Dynamic => DynamicStr == "true";
    
    public bool Disabled => DisabledStr == "true";
}