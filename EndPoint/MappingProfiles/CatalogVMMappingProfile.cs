
using Application.Catalogs.CatalogTypes.CrudService;
using AutoMapper;
using EndPoint.ViewModels.Catalogs;

namespace EndPoint.MappingProfiles
{
    public class CatalogVMMappingProfile:Profile
    {

        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeViewModel, CatalogTypeDto>().ReverseMap();
        }
       

    }
}
