using Application.Interfaces.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public GetMenuItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<MenuItemDto> Execute()
        {
            //نمایش اطلاعات ردیف پدر
            var catalogType = context.CatalogTypes.Include(p => p.ParentCatalogType)
                .ToList();
            var data = mapper.Map<List<MenuItemDto>>(catalogType);
            return data;
        }

        //public class CatalogType
        //{
        //    public int Id { get; set; }
        //    public string Type { get; set; }

        //    public int? ParentCatalogTypeId { get; set; }
        //    //اطلاعات ردیف پدر
        //    public CatalogType ParentCatalogType { get; set; }

        //    //لیست فرزندان
        //    public ICollection<CatalogType> Children { get; set; }
        //}

        //public class MenuItemDto
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public int? ParentId { get; set; }
        //    public List<MenuItemDto> SubMenu { get; set; }
        //}
    }
}
