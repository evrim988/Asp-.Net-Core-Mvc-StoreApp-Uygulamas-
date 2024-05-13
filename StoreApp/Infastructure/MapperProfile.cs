using AutoMapper;
using Entities;
using Entities.Dtos.Category;
using Entities.Dtos.Product;
using Entities.Entities;

namespace Services.Infastructure;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<UpdateProductDTO, Product>().ReverseMap();

        CreateMap<CategoryDTO, Category>();
        CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
    }
}
