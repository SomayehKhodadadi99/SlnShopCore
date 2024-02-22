using Application.Catalogs.CatalogTypes.CrudService;
using Application.DTOGeneral;
using AutoMapper;
using Domain.Catalogs;
using EndPoint.Models.ViewModels.User.Login;
using EndPoint.ViewModels.Catalogs;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Areas.Admin.Controllers.CategoryType
{
    [Area("Admin")]
    public class CategoryTypeController : Controller
    {
        List<string> msg = new List<string>();
        //CatalogTypeViewModel CategoryTypeVM = new CatalogTypeViewModel();
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;
        public CategoryTypeController(ICatalogTypeService _catalogTypeService,IMapper _mapper)
        {
            catalogTypeService = _catalogTypeService;
            mapper = _mapper;
        }
        public PaginatedItemsDto<CatalogTypeListDto> CatalogList { get; set; }

        public IActionResult Index(int? ParentId, int Page = 1, int PageSize = 100)
        {
            var CatalogList = catalogTypeService.GetList(ParentId, Page, PageSize);
            return View(CatalogList);
        }


        
        [HttpGet]
        public IActionResult Create(int? ParentId)
        {
            //CategoryTypeVM.ParentCatalogTypeId = ParentId;
            //return View(CategoryTypeVM);

            return View(new CatalogTypeViewModel
            {
                ParentCatalogTypeId = ParentId
            }); ;
        }
        

        [HttpPost]
        public IActionResult Create(CatalogTypeViewModel frombody)
        {
           var modelDto= mapper.Map<CatalogTypeDto>(frombody);
          var Result=catalogTypeService.Add(modelDto);
       
           if (Result.IsSuccess)
            {

                return RedirectToPage("index", new { parentid = frombody.ParentCatalogTypeId });
            }
           else
            {
                msg=Result.Message;
            }
           return View();
         
        }
    }
}
