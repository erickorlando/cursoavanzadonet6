using AutoMapper;
using GalaxyApp.Dto.Request;
using GalaxyApp.Entidades;

namespace GalaxyApp.Servicios.Profiles;

public class InstructorProfile : Profile
{
    public InstructorProfile()
    {
        CreateMap<RequestInstructorDto, Instructor>()
            .ForMember(dest => dest.Id, origen => origen.MapFrom(x => x.IdInstructor))
            .ForMember(dest => dest.Nombres, origen => origen.MapFrom(x => x.Nombres))
            .ForMember(dest => dest.Apellidos, origen => origen.MapFrom(x => x.Apellidos))
            .ForMember(dest => dest.Email, origen => origen.MapFrom(x => x.Email))
            .ForMember(dest => dest.Celular, origen => origen.MapFrom(x => x.Celular))
            .ForMember(dest => dest.Dni, origen => origen.MapFrom(x => x.Dni));

    }
}