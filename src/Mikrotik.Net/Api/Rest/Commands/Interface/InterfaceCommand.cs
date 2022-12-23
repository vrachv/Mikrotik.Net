namespace Mikrotik.Net.Api.Rest.Commands.Interface;

public class InterfaceCommand : MikrotikCommand
{
    public override string Path => "interface";
    
    public override HttpMethod HttpMethod => HttpMethod.Get;
}