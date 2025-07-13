using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var data = _platformRepo.GetAllPlatforms();
            var mappedData = _mapper.Map<IEnumerable<PlatformReadDto>>(data);
            return Ok(mappedData);
        }
        [HttpGet("{id}", Name ="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var data = _platformRepo.GetPlatformBId(id);
            if (data != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(data));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform([FromBody] PlatformCreateDto dto)
        {
            var data = _mapper.Map<Platform>(dto);
            _platformRepo.CreatePlatform(data);
            _platformRepo.SaveChanges();
            var platformReadDto=_mapper.Map<PlatformReadDto>(data);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = data.Id }, platformReadDto);
        }
    }
}
