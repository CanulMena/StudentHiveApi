using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {             
          //src                   dest
        CreateMap<RentalHouse, PublicationDtos>();
        CreateMap<RentalHouseDetailCreateDTO, RentalHouseDetail>();//*Validated
        CreateMap<HouseServiceCreateDTO, HouseService>();//*Validated
        CreateMap<HouseLocationCreateDTO, Location>();//*Validated
        CreateMap<ImageRentalHouseCreateDTO, Image>();//*Validated
        CreateMap<IFormFile, Image>();

        CreateMap<RentalHouseCreateDTO, RentalHouse>()            //*Validated
        .AfterMap
        (
            (src, dest) => 
                {
                    dest.PublicationDate = DateTime.Now;
                }
        )
        .ForMember(dest => dest.IdHouseServiceNavigation, opt => opt.MapFrom(src => src.HouseService))
        .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.HouseLocation))
        .ForMember(dest => dest.IdRentalHouseDetailNavigation, opt => opt.MapFrom(src => src.DetailRentalHouse));
        //UserCreateDTO => User
        
        //Administrador
        CreateMap<Administrador, MasterDto>();
        CreateMap<CreateAdministradorDto, Administrador>()
        .AfterMap(
            (src, dest ) =>
            {
                dest.IdRol = 2;
            }
        );
    }
}
