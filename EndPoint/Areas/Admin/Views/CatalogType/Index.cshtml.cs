using Application.Catalogs.CatalogTypes.CrudService;
using Application.DTOGeneral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Areas.Admin.Views.CatalogType
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;
        public IndexModel(ICatalogTypeService _catalogTypeService)
        {
            catalogTypeService = _catalogTypeService;
        }
        public PaginatedItemsDto<CatalogTypeListDto> CatalogList { get; set; }
        public void OnGet(int? ParentId, int Page=1, int PageSize=100)
        {
            CatalogList=catalogTypeService.GetList(ParentId,Page,PageSize);
        }
    }
}
