using Newtonsoft.Json;

namespace Mikrotik.Net.Dtos;

public class MikrotikSystemResource
{
    [JsonProperty("architecture-name")]
    public string ArchitectureName { get; set; } = "";

    [JsonProperty("bad-blocks")]
    public string BadBlocks { get; set; } = "";

    [JsonProperty("board-name")]
    public string BoardName { get; set; } = "";

    [JsonProperty("build-time")]
    public string BuildTime { get; set; } = "";

    [JsonProperty("cpu")]
    public string Cpu { get; set; } = "";

    [JsonProperty("cpu-count")]
    public string CpuCount { get; set; } = "";

    [JsonProperty("cpu-frequency")]
    public string CpuFrequency { get; set; } = "";

    [JsonProperty("cpu-load")]
    public string CpuLoad { get; set; } = "";

    [JsonProperty("factory-software")]
    public string FactorySoftware { get; set; } = "";

    [JsonProperty("free-hdd-space")]
    public string FreeHddSpace { get; set; } = "";

    [JsonProperty("free-memory")]
    public string FreeMemory { get; set; } = "";

    [JsonProperty("platform")]
    public string Platform { get; set; } = "";

    [JsonProperty("total-hdd-space")]
    public string TotalHddSpace { get; set; } = "";

    [JsonProperty("total-memory")]
    public string TotalMemory { get; set; } = "";

    [JsonProperty("uptime")]
    public string Uptime { get; set; } = "";

    [JsonProperty("version")]
    public string Version { get; set; } = "";

    [JsonProperty("write-sect-since-reboot")]
    public string WriteSectSinceReboot { get; set; } = "";

    [JsonProperty("write-sect-total")]
    public string WriteSectTotal { get; set; } = "";
}