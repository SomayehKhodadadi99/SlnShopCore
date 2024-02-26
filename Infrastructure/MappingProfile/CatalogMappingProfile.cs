using Application.Catalogs.CatalogBrand;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Catalogs.CatalohItems.AddNewCatalogItem;
using Application.Catalogs.GetMenuItem;
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

            //----------------------------------------
            CreateMap<CatalogType, MenuItemDto>()
            .ForMember(dest => dest.Name, opt =>
             opt.MapFrom(src => src.Type))

            .ForMember(dest => dest.ParentId, opt =>
             opt.MapFrom(src => src.ParentCatalogTypeId))

            .ForMember(dest => dest.SubMenu, opt =>
            opt.MapFrom(src => src.Children));
            //---------------------------------------

            CreateMap<CatalogItemFeature, AddNewCatalogItemFeature_dto>().ReverseMap();
            CreateMap<CatalogItemImage, AddNewCatalogItemImage_Dto>().ReverseMap();

            CreateMap<CatalogItem, AddNewCatalogItemDto>()
                .ForMember(dest => dest.Features, opt =>
                opt.MapFrom(src => src.CatalogItemFeatures))
                 .ForMember(dest => dest.Images, opt =>
                 opt.MapFrom(src => src.CatalogItemImages)).ReverseMap();

            //-------------------
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();
            //---------------------------------------------
            CreateMap<CatalogBrand, CatalogBrandDto>().ReverseMap();
            

        }
    }
   

  
}
