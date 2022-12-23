namespace Mikrotik.Net.Api.Rest.Commands.Interface;

public class OpenVpnServerCommand : MikrotikCommand
{
    public override string Path => "interface/ovpn-server/server";
    
    public override HttpMethod HttpMethod => HttpMethod.Get;
}