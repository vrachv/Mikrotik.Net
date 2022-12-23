using Mikrotik.Net.Api.Rest;
using Mikrotik.Net.Api.Rest.Commands.Interface;
using Mikrotik.Net.Api.Rest.Commands.Ip;
using Mikrotik.Net.Api.Rest.Commands.System;
using Mikrotik.Net.Dtos;

namespace Mikrotik.Net;

public class MikrotikCommandService : IMikrotikCommandService
{
    public RestMikrotikConnection Connection { get; }

    public MikrotikCommandService(RestMikrotikConnection connection)
    {
        Connection = connection;
        
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(e => e.GetTypes())
            .Where(e => typeof(MikrotikCommand).IsAssignableFrom(e) && !e.IsAbstract).ToArray();
        
        _commands = new Dictionary<Type, MikrotikCommand>();
        foreach (var type in types)
        {
            _commands.Add(type, (MikrotikCommand) Activator.CreateInstance(type));
        }
    }

    private readonly Dictionary<Type, MikrotikCommand> _commands;

    public bool TryGetCommand<T>(out MikrotikCommand command)
    {
        if (_commands.TryGetValue(typeof(T), out var mikrotikCommand))
        {
            command = mikrotikCommand;
            return true;
        }
        
        command = default!;
        return false;
    }

    public void Execute<T>() where T : MikrotikCommand
    {
        if (_commands.TryGetValue(typeof(T), out var mikrotikCommand))
        {
            mikrotikCommand.Execute(Connection);
        }
    }
    
    public async Task<MikrotikResponse<TResponse>> ExecuteCommandAsync<TCommand, TResponse>()
        where TCommand : MikrotikCommand
    {
        if (_commands.TryGetValue(typeof(TCommand), out var mikrotikCommand))
        {
            var command = (TCommand)mikrotikCommand;
            return await command.ExecuteAsync<TResponse>(Connection);
        }

        return default!;
    }
    
    public async Task<MikrotikResponse> ExecuteCommandAsync<TCommand>()
        where TCommand : MikrotikCommand
    {
        if (_commands.TryGetValue(typeof(TCommand), out var mikrotikCommand))
        {
            var command = (TCommand)mikrotikCommand;
            return await command.ExecuteAsync(Connection);
        }

        return default!;
    }

    public async Task<MikrotikResponse<MikrotikSystemResource>> GetSystemResourceAsync()
    {
        return await ExecuteCommandAsync<SystemResourceCommand, MikrotikSystemResource>();
    }

    public async Task<MikrotikResponse<MikrotikIpAddress>> GetIpAddressAsync()
    {
        return await ExecuteCommandAsync<IpAddressCommand, MikrotikIpAddress>();
    }

    public async Task<MikrotikResponse> SystemBackupSaveAsync()
    {
        return await ExecuteCommandAsync<SystemBackupCommand>();
    }

    public async Task<MikrotikResponse<MikrotikInterface[]>> GetInterfaces()
    {
        return await ExecuteCommandAsync<InterfaceCommand, MikrotikInterface[]>();
    }

    public async Task<MikrotikResponse<MikrotikOpenVpnServer>> GetOpenVpnServer()
    {
        return await ExecuteCommandAsync<OpenVpnServerCommand, MikrotikOpenVpnServer>();
    }

    public async Task<MikrotikResponse> EnableOpenVpnServer()
    {
        return await ExecuteCommandAsync<OpenVpnServerEnableCommand>();
    }

    public async Task<MikrotikResponse> DisableOpenVpnServer()
    {
        return await ExecuteCommandAsync<OpenVpnServerDisableCommand>();
    }
}