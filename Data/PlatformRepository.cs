using PlatformService.Models;

namespace PlatformService.Data;
public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;
    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreatePlatform(Platform data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));
            
        _context.Platforms.Add(data);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
       return _context.SaveChanges() >= 0;
    }
}