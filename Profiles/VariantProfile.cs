using AutoMapper;

namespace ProductService.Profiles
{
    public class VariantProfile : Profile
    {
        public VariantProfile()
        {
            CreateMap<Entities.Variant, Models.VariantDTO>();
            CreateMap<Models.VariantDTO, Entities.Variant>();
        }

    }
}
