using AutoMapper;

namespace PlatformService;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }
}
