namespace PlatformService;

public interface IPlatformRepository
{
    bool SaveChanges();
    IEnumerable<Platform> GetPlatforms();
    Platform GetPlatformById(int Id);
    void Create(Platform platform);
}
