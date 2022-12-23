using Mikrotik.Net.Api.Rest;
using Mikrotik.Net.Dtos;

namespace Mikrotik.Net;

public interface IMikrotikCommandService
{
    bool TryGetCommand<T>(out MikrotikCommand command);
    
    void Execute<T>() where T : MikrotikCommand;
    
    Task<MikrotikResponse<TResponse>> ExecuteCommandAsync<TCommand, TResponse>() where TCommand : MikrotikCommand;
    
    Task<MikrotikResponse> ExecuteCommandAsync<TCommand>() where TCommand : MikrotikCommand;
    
    Task<MikrotikResponse<MikrotikSystemResource>> GetSystemResourceAsync();

    Task<MikrotikResponse<MikrotikIpAddress>> GetIpAddressAsync();

    Task<MikrotikResponse> SystemBackupSaveAsync();

    Task<MikrotikResponse<MikrotikInterface[]>> GetInterfaces();

    Task<MikrotikResponse<MikrotikOpenVpnServer>> GetOpenVpnServer();

    Task<MikrotikResponse> EnableOpenVpnServer();

    Task<MikrotikResponse> DisableOpenVpnServer();
}