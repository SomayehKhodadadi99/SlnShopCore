using Application.Catalogs.CatalogBrand;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Interfaces.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalohItems.CatalogItemServices
{
    public class CatalogItemService : ICatalogItemService
    {

        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public CatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<CatalogBrandDto> GetBrand()
        {
            var brands=context.CatalogBrands.OrderBy(p => p.Brand).Take(500).ToList();
            var data=mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var types = context.CatalogTypes
             .Include(p => p.ParentCatalogType)
             .Include(p => p.ParentCatalogType)
             .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
              .Include(p => p.Children)
              .Where(p => p.ParentCatalogTypeId != null)
              .Where(p => p.Children.Count == 0)
               .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.Children })
                              .ToList()
              .Select(p => new ListCatalogTypeDto
              {
                  Id = p.Id,
                  Type = $"{p?.Type ?? ""} - {p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}"
              }).ToList();
            return types;
        }
    }
}
