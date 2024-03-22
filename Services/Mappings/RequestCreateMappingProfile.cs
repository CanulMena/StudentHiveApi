using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()    
    {  

             
        CreateMap<UserCreateDTO, User>();
        // .ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => 1));
        
        CreateMap<RentalHouseCreateDto, RentalHouse>()
        .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.HouseLocation));


        CreateMap<RentalHouse, PublicationDtos>();
        CreateMap<RentalHouseDetailCreateDto, RentalHouseDetail>();//*Validated
        CreateMap<HouseServiceCreateDto, HouseService>();//*Validated
        CreateMap<HouseLocationCreateDto, Location>();//*Validated
        CreateMap<ImageRentalHouseCreateDTO, Image>();//*Validated
        CreateMap<IFormFile, Image>();

        CreateMap<RentalHouseCreateDto, RentalHouse>()            //*Validated
        .AfterMap
        (
            (src, dest) => 
                {
                    dest.PublicationDate = DateTime.Now;
                }
        )
        .AfterMap
        (
            (src, dest) => 
                {
                    dest.StatusRent = true;
                }
        )
        .AfterMap
        (
            (src, dest) => 
                {
                    dest.Status = false;
                }
        )
        .ForMember(dest => dest.IdHouseServiceNavigation, opt => opt.MapFrom(src => src.HouseService))
        .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.HouseLocation))
        .ForMember(dest => dest.IdRentalHouseDetailNavigation, opt => opt.MapFrom(src => src.DetailRentalHouse));
        //UserCreateDTO => User
        
        // //Administrador
        // CreateMap<Administrador, MasterDto>();
        // CreateMap<CreateAdministradorDto, Administrador>()
        // .AfterMap(
        //     (src, dest ) =>
        //     {
        //         dest.IdRol = 2;
        //     }
        // );

        //Request
        CreateMap<CreateRequestDto, Request>()
        .AfterMap(
            (src, dest ) =>
            {
                dest.CreatedAt = DateTime.Now;
            }
        )
        .AfterMap(
            (src, dest) =>
            {
                dest.Status = "Pendiente";
            }
        );

        //ReportPublication
        CreateMap<CreateReportDTO, Report>()
        .ForMember(dest => dest.IdPublication, opt => opt.MapFrom(src => src.Idpublication))
        .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUser))
        .ForMember(dest => dest.IdTypeReport, opt => opt.MapFrom(src => src.IdReportType))
        .AfterMap(
            (src, dest ) =>
            {
                dest.CreatedAt = DateTime.Now;
            }
        );
    }
}
