
using Humanizer;

namespace PlatformService;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _dbContext;
    public PlatformRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Platform platform)
    {
        if (platform is null)
            throw new ArgumentNullException();

        _dbContext.Add<Platform>(platform);
    }

    public Platform GetPlatformById(int Id)
    {
        var platform = _dbContext.Platforms.FirstOrDefault(x => x.Id == Id);
        return platform ?? throw new NoMatchFoundException();
    }

    public IEnumerable<Platform> GetPlatforms()
    {
        var platforms = _dbContext.Platforms.ToList();
        return platforms ?? throw new NoMatchFoundException();
    }

    public bool SaveChanges()
    {
        return _dbContext.SaveChanges() > 0;
    }
}
