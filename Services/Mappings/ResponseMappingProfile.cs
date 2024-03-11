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
        // CreateMap<RentalHouse,UserRentalHouseDTO>();
        // CreateMap<HouseService,HouseServiceDTO>();
        // CreateMap<Location,HouseLocationDTO>();
        // CreateMap<RentalHouseDetail,RentalHouseDetailDTO>();
        // CreateMap<Image,ImageRentalHouseDTO>();

                //Publication
        CreateMap<RentalHouse, PublicationDtos>()
        .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).ToList()))
        .ForMember(dest => dest.HouseLocation, opt => opt.MapFrom(src => src.IdLocationNavigation))
        .ForMember(dest => dest.NameofUser, opt => opt.MapFrom(src => src.IdUserNavigation!.Name));

        //RentalHouse 
        CreateMap<RentalHouse, RentalHouseDto>()
        .ForMember(dest => dest.IdHouseServiceNavigation, opt => opt.MapFrom(src => src.IdHouseServiceNavigation))
        .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.IdLocationNavigation))
        .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUserNavigation!.IdUser))
        .ForMember(dest => dest.IdRentalHouseDetailNavigation, opt => opt.MapFrom(src => src.IdRentalHouseDetailNavigation))
        .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).ToList()));

        CreateMap<HouseService, HouseServiceDto>();
        CreateMap<Location, HouseLocationDto>();
        CreateMap<User, UserDTO>();
        CreateMap<RentalHouseDetail, RentalHouseDetailDto>();
        CreateMap<Image, ImageRentalHouseDto>();


        
        //Administrador
        CreateMap<Administrador, MasterDto>()
        .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.IdRolNavigation!.NombreRol));
    
        //Request
        CreateMap<Request, RequestDto>()
        .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUserNavigation!.IdUser))
        .ForMember(dest => dest.IdPublication, opt => opt.MapFrom(src => src.IdPublicationNavigation!.IdPublication));

        //ReportPublication

        CreateMap<RentalHouse, RepotedPublicationDtos>()
        .ForMember(dest => dest.IdPublication, opt => opt.MapFrom(src => src.IdPublication))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).ToList()))
        .ForMember(dest => dest.WebUser, opt => opt.MapFrom( src => src.IdUserNavigation))
        .ForMember(dest => dest.IdReport, opt => opt.MapFrom( src => src.IdReport.Select(x => x.IdReport).ToList()))
        .ForMember(dest => dest.TypeReport, opt => opt.MapFrom( src => src.IdTypeReportNavigation));

        CreateMap<RentalHouse, PublicationToBeAprovedDto>()
        .ForMember(dest => dest.IdPublication, opt => opt.MapFrom(src => src.IdPublication))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).ToList()))
        .ForMember(dest => dest.dateTime, opt => opt.MapFrom(src => src.PublicationDate))
        .ForMember(dest => dest.WebLocationDtos, opt => opt.MapFrom(src => src.IdLocationNavigation))
        .ForMember(dest => dest.WebUser, opt => opt.MapFrom(src => src.IdUserNavigation))
        ; 

        CreateMap<Report, ReportDtos>();
        CreateMap<ReportType,TypeReportDto>();
        CreateMap<User, WebUserDtos>();
        CreateMap<Location, WebLocationDtos>();
    }
}