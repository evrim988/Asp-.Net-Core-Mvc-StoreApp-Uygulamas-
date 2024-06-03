using AutoMapper;
using Entities;
using Entities.Dtos.Category;
using Entities.Dtos.Product;
using Entities.Dtos.User;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace Services.Infastructure;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<UpdateProductDTO, Product>().ReverseMap();

        CreateMap<CategoryDTO, Category>();
        CreateMap<UpdateCategoryDTO, Category>().ReverseMap();

        CreateMap<UserDtoForCreation, IdentityUser>();
        CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
    }
}
