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
        CreateMap<User, UserPublicationDto>()
        .ForMember(dest => dest.publications, opt => opt.MapFrom(src => src.RentalHouses.Select(x => x).ToList()));
        CreateMap<RentalHouse, publicationUserDto>()
        .ForMember(dest => dest.FirstImage, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).FirstOrDefault()))
        .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.PublicationDate))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.IdPublication, opt => opt.MapFrom(src => src.IdPublication));


                //Publication
        CreateMap<RentalHouse, PublicationDtos>()
        .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).ToList()))
        .ForMember(dest => dest.HouseLocation, opt => opt.MapFrom(src => src.IdLocationNavigation))
        .ForMember(dest  => dest.Email, opt => opt.MapFrom(src => src.IdUserNavigation!.Email))
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
        // CreateMap<Administrador, MasterDto>()
        // .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.IdRolNavigation!.NombreRol));
    
        //Request
        CreateMap<Request, RequestDto>()
        .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUserNavigation!.IdUser))
        .ForMember(dest => dest.IdPublication, opt => opt.MapFrom(src => src.IdPublicationNavigation!.IdPublication));

        //ReportPublication
        CreateMap<Report, ReportDto>()
        .ForMember(dest => dest.IdUserNavigation, opt => opt.MapFrom(src => src.IdUserNavigation))
        .ForMember(dest => dest.IdReportType, opt => opt.MapFrom(src => src.IdTypeReport))
        .ForMember(dest => dest.IdPublicationNavigation, opt => opt.MapFrom(src => src.IdPublication1))
        .ForMember(dest => dest.TypeReportName, opt => opt.MapFrom(src => src.IdTypeReportNavigation!.TypeReportName))
        .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
            
        CreateMap<User, UserReportDto>();
        CreateMap<RentalHouse, PublicationReportDto>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).FirstOrDefault()));

        CreateMap<RentalHouse, PublicationWithReportsDto>()
        .ForMember(dest => dest.Reports, opt => opt.MapFrom(src => src.Reports))
        .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.Select(x => x.UrlImageHouse).FirstOrDefault()))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.IdPublication, opt => opt.MapFrom(src => src.IdPublication));

        CreateMap<Report, ReportsDto>()
        .ForMember(dest => dest.TypeReportName, opt => opt.MapFrom(src => src.IdTypeReportNavigation!.TypeReportName));
    }
}