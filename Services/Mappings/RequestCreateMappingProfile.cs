using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {               
        CreateMap<UserCreateDTO, User>()
        .ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => 1));
        
        CreateMap<RentalHouseCreateDTO, RentalHouse>()
        .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.HouseLocation));


        CreateMap<RentalHouse, PublicationDtos>();
        CreateMap<RentalHouseDetailCreateDto, RentalHouseDetail>();//*Validated
        CreateMap<HouseServiceCreateDto, HouseService>();//*Validated
        CreateMap<HouseLocationCreateDto, Location>();//*Validated
        CreateMap<ImageRentalHouseCreateDTO, Image>();//*Validated
        CreateMap<IFormFile, Image>();

        //Mapeo del CreateReportDTO a Report
        CreateMap<CreateReportDTO, Report>();
        
            // .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => new List<User> { new User { IdUser = src.IdUser } }));

        CreateMap<RentalHouseCreateDto, RentalHouse>()            //*Validated
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
