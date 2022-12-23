namespace Mikrotik.Net.Api.Rest.Commands.System;

public class SystemBackupCommand : MikrotikCommand
{
    public override string Path => "system/backup/save";
    
    public override HttpMethod HttpMethod => HttpMethod.Post;
}