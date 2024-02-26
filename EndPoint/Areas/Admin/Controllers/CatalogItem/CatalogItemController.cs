using Application.Catalogs.CatalogTypes.CrudService;
using Application.Catalogs.CatalohItems.AddNewCatalogItem;
using Application.Catalogs.CatalohItems.CatalogItemServices;
using AutoMapper;
using EndPoint.ViewModels.Catalogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Areas.Admin.Controllers.CatalogItem
{
    [Area("Admin")]
    public class CatalogItemController : Controller
    {

        private readonly IAddNewCatalogItemService addNewCatalogItemService;
        private readonly ICatalogItemService catalogItemService;
        private readonly IMapper mapper;
       
        public CatalogItemController(IAddNewCatalogItemService _addNewCatalogItemService
            ,ICatalogItemService _catalogItemService
            , IMapper _mapper)
        {
            catalogItemService = _catalogItemService;
            mapper = _mapper;
            addNewCatalogItemService=_addNewCatalogItemService;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {

            AddNewCatalogItemViewModel catalogItem = new AddNewCatalogItemViewModel();
            catalogItem.CatalogTypeList = new SelectList(catalogItemService.GetCatalogType(), "Id", "Type");
            catalogItem.CatalogBrandList = new SelectList(catalogItemService.GetBrand(), "Id", "Brand");

            return View(catalogItem);
         
        }


        [HttpPost]
        public IActionResult Create(AddNewCatalogItemViewModel frombody)
        {
            //var modelDto = mapper.Map<CatalogTypeDto>(frombody);
            //var Result = catalogTypeService.Add(modelDto);

            //if (Result.IsSuccess)
            //{

            //    return RedirectToAction("index", new { ParentCatalogTypeId = frombody.ParentCatalogTypeId });
            //}
            //else
            //{
            //    msg = Result.Message;
            //}
            return View();

        }
    }
}
