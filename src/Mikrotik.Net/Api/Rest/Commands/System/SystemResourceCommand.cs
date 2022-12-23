namespace Mikrotik.Net.Api.Rest.Commands.System;

public class SystemResourceCommand : MikrotikCommand
{
    public override string Path => "system/resource";
    
    public override HttpMethod HttpMethod => HttpMethod.Get;
}