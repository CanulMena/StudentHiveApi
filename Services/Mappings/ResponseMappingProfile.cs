using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class ResponseMappingProfile : Profile 
{
    public ResponseMappingProfile() //this is how I want my entity to be transformed into a DTO
    {       //User => UserDTO
        CreateMap<User,UserDTO>();
        CreateMap<RentalHouse,UserRentalHouseDTO>();
        CreateMap<HouseService,HouseServiceDTO>();
        CreateMap<Location,HouseLocationDTO>();
        CreateMap<RentalHouseDetail,RentalHouseDetailDTO>();
        CreateMap<Image,ImageRentalHouseDTO>();
        CreateMap<Report, ReportDTO>();

        //Reportes 
        CreateMap<Report, ReportDTO>()
        .ForMember(dest => dest.IdReportTypeNavigation, opt => opt.MapFrom(src => src.IdReportType));

                //Publication
        CreateMap<RentalHouse, PublicationDtos>()
        .ForMember(dest => dest.Image_Url_P, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).ToList()))
        .ForMember(dest => dest.NameofUser, opt => opt.MapFrom(src => src.IdUserNavigation!.Name));

        //RentalHouse 
        CreateMap<RentalHouse, RentalHouseDto>()
        .ForMember(dest => dest.IdHouseServiceNavigation, opt => opt.MapFrom(src => src.IdHouseServiceNavigation))
        .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.IdLocationNavigation))
        .ForMember(dest => dest.IdUserNavigation, opt => opt.MapFrom(src => src.IdUserNavigation))
        .ForMember(dest => dest.IdRentalHouseDetailNavigation, opt => opt.MapFrom(src => src.IdRentalHouseDetailNavigation))
        .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

        CreateMap<HouseService, HouseServiceDto>();
        CreateMap<Location, HouseLocationDto>();
        CreateMap<User, UserDTO>();
        CreateMap<RentalHouseDetail, RentalHouseDetailDto>();
        CreateMap<Image, ImageRentalHouseDto>();


        
        //Administrador
        CreateMap<Administrador, MasterDto>()
        .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.IdRolNavigation!.NombreRol));
    
        

    }
}