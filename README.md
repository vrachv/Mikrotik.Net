# Mikrotik.Net

C# simple wrapper for RouterOS Rest API (mikrotik).

The project has few built-in commands at the moment. But it is easily expandable.

I will add more built-in commands if I have free time.

## Usage
Create connection.
```csharp
var connection = new RestMikrotikConnection(new Uri("https://192.168.88.1"), "login", "password", ignoreCertificate: true, debug: true);
```

#### Easy way.
```csharp
var result = await connection.SendAsync<InterfaceResponseDto>(HttpMethod.Get, "interface");
```

#### Recommended way.

Create command service.
```csharp
var commandService = new MikrotikCommandService(connection);
```

Use existing methods.
```csharp
var interfaces = await commandService.GetInterfaces();
```

Create your command.
```csharp
public class InterfaceCommand : MikrotikCommand
{
    public override string Path => "interface";
    
    public override HttpMethod HttpMethod => HttpMethod.Get;
}
```

Call your command.
```csharp
MikrotikResponse response = await commands.ExecuteCommandAsync<InterfaceCommand, MikrotikInterface[]>(); // if need deserialize
MikrotikInterface[] interfaces = response.Deserialize();

MikrotikResponse response = await commands.ExecuteCommandAsync<InterfaceCommand>(); // if not need deserialize

commands.Execute<InterfaceCommand>(); // if not need result
```

Extend command service.
```csharp
public static class MikrotikCommandsExtensions
{
    public static async Task<MikrotikResponse<MikrotikInterface[]>> GetInterfaces(this MikrotikCommandService commandService)
    {
        return await commandService.ExecuteCommandAsync<InterfaceCommand, MikrotikInterface[]>();
    }
}
```

## Contribute
Feel free to contribute.