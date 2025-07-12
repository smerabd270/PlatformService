using PlatformService.Models;

namespace PlatformService
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformBId(int id); 
        void CreatePlatform(Platform plat);

    }
}
