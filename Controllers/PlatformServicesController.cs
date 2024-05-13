using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService;

[ApiController]
[Route("api/[controller]")]
public class PlatformServicesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;
    private readonly IPlatformRepository _platformRepository;
    public PlatformServicesController(
         IPlatformRepository platformRepository,
         IMapper mapper,
         ICommandDataClient commandDataClient)
    {
        _mapper = mapper;
        _commandDataClient = commandDataClient;
        _platformRepository = platformRepository;
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<PlatformReadDto> GetById(int Id)
    {
        var platform = _platformRepository.GetPlatformById(Id);
        return Ok(_mapper.Map<PlatformReadDto>(platform));
    }

    [HttpGet(Name = "GetAll")]
    public ActionResult<IEnumerable<PlatformReadDto>> GetAll()
    {
        var platforms = _platformRepository.GetPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpPost(Name = "Create")]
    public async Task<ActionResult<PlatformReadDto>> Create([FromBody] PlatformCreateDto platformCreateDto)
    {
        var platformModel = _mapper.Map<Platform>(platformCreateDto);
        _platformRepository.Create(platformModel);
        _platformRepository.SaveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

        try
        {
            await _commandDataClient.SendPlatformToCommand(platformReadDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not send syncronously: {ex.Message}");
        }

        return CreatedAtRoute(nameof(GetById), new { Id = platformReadDto.Id }, platformReadDto);
    }
}
