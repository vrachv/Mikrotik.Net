using Newtonsoft.Json;

namespace Mikrotik.Net.Dtos;

public class MikrotikOpenVpnServer
{
    [JsonProperty("auth")]
    public string Auth { get; set; }

    [JsonProperty("certificate")]
    public string Certificate { get; set; }

    [JsonProperty("cipher")]
    public string Cipher { get; set; }

    [JsonProperty("default-profile")]
    public string DefaultProfile { get; set; }

    [JsonProperty("enabled")]
    internal string EnabledStr { get; set; }

    [JsonProperty("keepalive-timeout")]
    public string KeepaliveTimeout { get; set; }

    [JsonProperty("mac-address")]
    public string MacAddress { get; set; }

    [JsonProperty("max-mtu")]
    public string MaxMtu { get; set; }

    [JsonProperty("mode")]
    public string Mode { get; set; }

    [JsonProperty("netmask")]
    public string Netmask { get; set; }

    [JsonProperty("port")]
    public string Port { get; set; }

    [JsonProperty("protocol")]
    public string Protocol { get; set; }

    [JsonProperty("require-client-certificate")]
    internal string RequireClientCertificateStr { get; set; }

    [JsonProperty("tls-version")]
    public string TlsVersion { get; set; }

    public bool Enabled => EnabledStr == "true";

    public bool RequireClientCertificate => RequireClientCertificateStr == "true";
}