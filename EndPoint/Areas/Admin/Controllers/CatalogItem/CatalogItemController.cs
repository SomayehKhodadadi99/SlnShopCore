using Application.Catalogs.CatalogBrand;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Catalogs.CatalohItems.AddNewCatalogItem;
using Application.Catalogs.CatalohItems.CatalogItemServices;
using Application.DTOGeneral;
using AutoMapper;
using EndPoint.ViewModels.Catalogs;
using Infrastructure.ExternalApi.ImageServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EndPoint.Areas.Admin.Controllers.CatalogItem
{
    [Area("Admin")]
    public class CatalogItemController : Controller
    {

        private readonly IAddNewCatalogItemService addNewCatalogItemService;
        private readonly ICatalogItemService catalogItemService;
        private readonly IImageUploadService    imageUploadService;
        private readonly IMapper mapper;
       
        public CatalogItemController(IAddNewCatalogItemService _addNewCatalogItemService
            ,ICatalogItemService _catalogItemService
            , IImageUploadService _imageUploadService
            , IMapper _mapper)
        {
            catalogItemService = _catalogItemService;
            mapper = _mapper;
            addNewCatalogItemService=_addNewCatalogItemService;
            imageUploadService = _imageUploadService;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {

            AddNewCatalogItemViewModel catalogItem = new AddNewCatalogItemViewModel();

       
            List<ListCatalogTypeDto> Types=catalogItemService.GetCatalogType();
            List<CatalogBrandDto> Brands = catalogItemService.GetBrand();



            
            catalogItem.CatalogTypeList = Types.Select(p=>new SelectListItem { Text=p.Type,Value=p.Id.ToString()}).ToList();
            catalogItem.CatalogBrandList = Brands.Select(p => new SelectListItem { Text = p.Brand, Value = p.Id.ToString() }).ToList();

       

            return View(catalogItem);
         
        }

        public List<IFormFile> ListFiles { get; set; }
        public AddNewCatalogItemDto _addNewCatalogItemDto { get; set; }

        [HttpPost]
        public IActionResult Create(AddNewCatalogItemDto frombody)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new JsonResult(new BaseDto<int>(0, false, allErrors.Select(p => p.ErrorMessage).ToList()));
            }
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                ListFiles.Add(file);
            }
            //ابتدا آپلود می کنیم
            //وقتی آپلود می کنیم آدرس بر می گردونه
            //_addNewCatalogItemDto لیست آدرس  عکس ها را  هم دارد
            //خروجی آپلود ، لیست آدرس می باشد

            List<AddNewCatalogItemImage_Dto> ListImages = new List<AddNewCatalogItemImage_Dto>();
            if (ListFiles.Count > 0)
            {
                //Upload 
                //بعد از آپلود لیست آدرس را بر می گردونه
              var result=imageUploadService.Upload(ListFiles);
                foreach (var item in result)
                {
                    //آن آدرس ها را می گیریم و به ازای هر  کاتالوگ ذخیره می کنیم
                    ListImages.Add(new AddNewCatalogItemImage_Dto { Src = item });
                }
            }


            _addNewCatalogItemDto.ListSrcImages = ListImages;
            var resultService = addNewCatalogItemService.Execute(_addNewCatalogItemDto);
            return new JsonResult(resultService);


        }
    }
}
