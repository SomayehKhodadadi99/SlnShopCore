using Application.DTOGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalohItems.AddNewCatalogItem
{
    public interface IAddNewCatalogItemService
    {
        //خروجی آی دی از جنس int
        BaseDto<int> Execute(AddNewCatalogItemDto request);
    }
}
