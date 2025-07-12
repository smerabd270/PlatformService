using PlatformService.Models;

namespace PlatformService
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<IPlatformRepo> GetAllPlatforms();
        Platform GetPlatformBId(int bId); 
        void CreatePlatform(Platform plat);

    }
}
