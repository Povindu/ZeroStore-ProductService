using AutoMapper;

namespace ProductService.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Maps fields with same name of the Product Entity with ProductDTO

            CreateMap<Entities.Product, Models.ProductwithoutVariantDTO>();
            CreateMap<Entities.Product, Models.ProductDTO>();
            CreateMap<Entities.Product, Models.ProductCreateDTO>();
            CreateMap<Models.ProductCreateDTO, Entities.Product>();
            CreateMap<Entities.Product, Models.ProductUpdateDTO>();
            CreateMap<Models.ProductUpdateDTO, Entities.Product>();

        }
    }
}
