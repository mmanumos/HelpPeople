using AutoMapper;
using HelpPeople.Models;
using HelpPeople.Models.DTO;

namespace HelpPeople.AutoMapper
{
    public class HelpPeopleProfile: Profile
    {
        public HelpPeopleProfile() { 

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
            });
        
            configuration.CompileMappings();
            configuration.AssertConfigurationIsValid();

            #region mapping
            CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.IdPersona))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.CorreoElectronico, opt => opt.MapFrom(src => src.CorreoElectronico))
                .ForMember(dest => dest.TipoDocumento, opt => opt.MapFrom(src => src.TipoDocumento))
                .ForMember(dest => dest.NroDocumento, opt => opt.MapFrom(src => src.NroDocumento))
                .ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => src.FechaRegistro));

            #endregion
        }

    }
}
