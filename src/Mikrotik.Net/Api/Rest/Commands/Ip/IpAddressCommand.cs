namespace Mikrotik.Net.Api.Rest.Commands.Ip;

public class IpAddressCommand : MikrotikCommand
{
    public override string Path => "ip/address";
    
    public override HttpMethod HttpMethod => HttpMethod.Get;
}