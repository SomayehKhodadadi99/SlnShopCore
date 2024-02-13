using Application.DTOGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogTypes.CrudService
{
    public interface ICatalogTypeService
    {
        BaseDto<CatalogTypeDto> FindById(int Id);
        BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType);
        BaseDto Remove(int Id);
        BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType);
        PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize);
    }


}
