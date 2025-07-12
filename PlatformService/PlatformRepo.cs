using PlatformService.Data;
using System.Linq

using PlatformService.Models;

namespace PlatformService
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform plat)
        {
            _context.Platforms.Add(plat);
        }

        public IEnumerable<IPlatformRepo> GetAllPlatforms()
        {
            return (IEnumerable<IPlatformRepo>)_context.Platforms.ToList();
        }

        public Platform GetPlatformBId(int bId)
        {
            return _context.Platforms.FirstOrDefault(x => x.Id == bId);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges()>=0);
        }
    }
}
