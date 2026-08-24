using AutoMapper;
using Assignment_3.DTOs;
using Assignment_3.Models;

namespace Assignment_3.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductItemDto>();

            CreateMap<CreatedProductRequest, Product>()
                .ForMember
                (
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(_ => DateTime.UtcNow)


                );


        }
                
    }
}
