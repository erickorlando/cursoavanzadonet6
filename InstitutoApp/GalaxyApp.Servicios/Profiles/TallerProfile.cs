using AutoMapper;
using GalaxyApp.Dto.Request;
using GalaxyApp.Entidades;

namespace GalaxyApp.Servicios.Profiles;

public class TallerProfile : Profile
{
    public TallerProfile()
    {
        CreateMap<RequestTallerDto, Taller>()
            .ForMember(dest => dest.Nombre, origen => origen.MapFrom(x => x.Nombre))
            .ForMember(dest => dest.CategoriaId, origen => origen.MapFrom(x => x.CategoriaId))
            .ForMember(dest => dest.FechaInicio,
                origen => origen.MapFrom(x => Convert.ToDateTime($"{x.FechaInicio} {x.HoraInicio}")))
            .ForMember(dest => dest.Situacion, origen => origen.MapFrom(x => (SituacionEnum)x.Situacion))
            .ForMember(dest => dest.InstructorId,
                origen => origen.MapFrom(x => x.RequestInstructorDto.IdInstructor ?? 0));


        CreateMap<RequestTemaDto, Tema>()
            .ForMember(dest => dest.Nombre, origen => origen.MapFrom(x => x.NombreTema));


    }
}