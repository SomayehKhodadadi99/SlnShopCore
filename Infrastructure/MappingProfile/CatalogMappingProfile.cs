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


            //روش این بهتره فقط میره کانت رو میاره ، نه همه رو
            CreateMap<CatalogType, CatalogTypeListDto>()
            .ForMember(dest => dest.SubTypeCount, option =>
            option.MapFrom(src => src.SubType.Count));
        }
    }
    //public class CatalogType
    //{
    //    public int Id { get; set; }
    //    public string Type { get; set; }

    //    public int? ParentCatalogTypeId { get; set; }
    //    اطلاعات ردیف پدر
    //    public CatalogType ParentCatalogType { get; set; }

    //    لیست فرزندان
    //    public ICollection<CatalogType> SubType { get; set; }
    //}


    //public class CatalogTypeListDto
    //{
    //    public int Id { get; set; }
    //    public string Type { get; set; }
    //    // تعداد فرزندان
    //    public int SubTypeCount { get; set; }
    //}
}
