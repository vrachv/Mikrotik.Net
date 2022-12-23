using System.Globalization;
using Newtonsoft.Json;

namespace Mikrotik.Net.Dtos;

public class MikrotikInterface
{
    [JsonProperty(".id")]
    public string Id { get; set; }

    [JsonProperty("actual-mtu")]
    public string ActualMtu { get; set; }

    [JsonProperty("default-name")]
    public string DefaultName { get; set; }

    [JsonProperty("disabled")]
    public string DisabledStr { get; set; }

    [JsonProperty("fp-rx-byte")]
    public string FpRxByte { get; set; }

    [JsonProperty("fp-rx-packet")]
    public string FpRxPacket { get; set; }

    [JsonProperty("fp-tx-byte")]
    public string FpTxByte { get; set; }

    [JsonProperty("fp-tx-packet")]
    public string FpTxPacket { get; set; }

    [JsonProperty("l2mtu")]
    public string L2mtu { get; set; }

    [JsonProperty("last-link-up-time")]
    public string LastLinkUpTimeStr { get; set; }

    [JsonProperty("link-downs")]
    public string LinkDowns { get; set; }

    [JsonProperty("mac-address")]
    public string MacAddress { get; set; }

    [JsonProperty("max-l2mtu")]
    public string MaxL2mtu { get; set; }

    [JsonProperty("mtu")]
    public string Mtu { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("running")]
    public string RunningStr { get; set; }

    [JsonProperty("rx-byte")]
    public string RxByte { get; set; }

    [JsonProperty("rx-drop")]
    public string RxDrop { get; set; }

    [JsonProperty("rx-error")]
    public string RxError { get; set; }

    [JsonProperty("rx-packet")]
    public string RxPacket { get; set; }

    [JsonProperty("tx-byte")]
    public string TxByte { get; set; }

    [JsonProperty("tx-drop")]
    public string TxDrop { get; set; }

    [JsonProperty("tx-error")]
    public string TxError { get; set; }

    [JsonProperty("tx-packet")]
    public string TxPacket { get; set; }

    [JsonProperty("tx-queue-drop")]
    public string TxQueueDrop { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("comment")]
    public string Comment { get; set; }

    [JsonProperty("slave")]
    public string Slave { get; set; }

    [JsonProperty("last-link-down-time")]
    public string LastLinkDownTimeStr { get; set; }
    
    public bool Disabled => DisabledStr == "true";

    public bool Running => RunningStr == "true";

    public DateTime? LastLinkDownTime => DateTime.TryParseExact(LastLinkDownTimeStr, "MMM/dd/yyyy HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt) ? dt : null;
    
    public DateTime? LastLinkUpTime => DateTime.TryParseExact(LastLinkUpTimeStr, "MMM/dd/yyyy HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt) ? dt : null;
}