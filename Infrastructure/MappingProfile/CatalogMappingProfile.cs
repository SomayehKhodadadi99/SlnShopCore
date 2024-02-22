using Application.Catalogs.CatalogTypes.CrudService;
using Application.DTOGeneral;
using AutoMapper;
using Domain.Catalogs;




namespace Infrastructure.MappingProfile
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();


            //<source,Destination>
            //روش این بهتره فقط میره کانت رو میاره ، نه همه رو
            CreateMap<CatalogType, CatalogTypeListDto>()
            .ForMember(dest => dest.ChildrenCount, option =>
            option.MapFrom(src => src.Children.Count));


           
        }
    }
   

  
}
