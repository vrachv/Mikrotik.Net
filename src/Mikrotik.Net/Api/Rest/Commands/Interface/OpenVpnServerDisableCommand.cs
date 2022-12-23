namespace Mikrotik.Net.Api.Rest.Commands.Interface;

public class OpenVpnServerDisableCommand : MikrotikCommand
{
    public override string Path => "interface/ovpn-server/server/set";
    public override HttpMethod HttpMethod => HttpMethod.Post;

    public override string Content => $$"""
    {
        "enabled": "no"
    }
    """;
}