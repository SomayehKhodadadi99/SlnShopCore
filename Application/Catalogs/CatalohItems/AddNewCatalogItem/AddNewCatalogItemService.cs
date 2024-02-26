using Application.DTOGeneral;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalohItems.AddNewCatalogItem
{
    public class AddNewCatalogItemService : IAddNewCatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<int> Execute(AddNewCatalogItemDto request)
        {
            var catalogItem = mapper.Map<CatalogItem>(request);
            context.CatalogItems.Add(catalogItem);
            context.SaveChanges();
            return new BaseDto<int>(catalogItem.Id,true, new List<string> { "با موفقیت ثبت شد" } );
        }
    }

}
