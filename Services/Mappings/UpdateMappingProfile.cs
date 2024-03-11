using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.Update;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class UpdateMappingProfile : Profile 
{
    public UpdateMappingProfile() 
    {
                    // =>     new User entity
        CreateMap<UserUpdateDTO,User>();
        CreateMap<CompleteUserInformationDTO,User>();


        CreateMap<RentalHouseUpdateDto, RentalHouse>()
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.RentPrice, opt => opt.MapFrom(src => src.RentPrice));

        CreateMap<HouseDetailUpdateDto, RentalHouseDetail>();
        CreateMap<HouseLocationUpdateDto, Location>();
        CreateMap<HouseServiceUpdateDto, HouseService>();

    }
}