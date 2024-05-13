namespace PlatformService;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(PlatformReadDto platform);
}
