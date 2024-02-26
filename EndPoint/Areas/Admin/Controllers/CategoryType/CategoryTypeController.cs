using Application.Catalogs.CatalogTypes.CrudService;
using Application.DTOGeneral;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Catalogs;
using EndPoint.Models.ViewModels.User.Login;
using EndPoint.ViewModels.Catalogs;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace EndPoint.Areas.Admin.Controllers.CategoryType
{
    [Area("Admin")]
    public class CategoryTypeController : Controller
    {
        List<string> msg = new List<string>();
    
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;
        //private readonly IDataBaseContext context;
        public CategoryTypeController(ICatalogTypeService _catalogTypeService,IMapper _mapper)
        {
            catalogTypeService = _catalogTypeService;
            mapper = _mapper;
            //context = _context;
        }
        public PaginatedItemsDto<CatalogTypeListDto> CatalogList { get; set; }

        public IActionResult Index(int? ParentId, int Page = 1, int PageSize = 100)
        {
            var CatalogList = catalogTypeService.GetList(ParentId, Page, PageSize);
            return View(CatalogList);
        }


        
        [HttpGet]
        public IActionResult Create(int? ParentCatalogTypeId)
        {
            //CategoryTypeVM.ParentCatalogTypeId = ParentId;
            //return View(CategoryTypeVM);

            return View(new CatalogTypeViewModel
            {
                ParentCatalogTypeId = ParentCatalogTypeId
            }); ;
        }
        

        [HttpPost]
        public IActionResult Create( CatalogTypeViewModel frombody)
        {
           var modelDto= mapper.Map<CatalogTypeDto>(frombody);
          var Result=catalogTypeService.Add(modelDto);
       
           if (Result.IsSuccess)
            {

                return RedirectToAction("index", new { ParentCatalogTypeId = frombody.ParentCatalogTypeId });
            }
           else
            {
                msg=Result.Message;
            }
           return View();
         
        }
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel();

        public List<String> Message { get; set; } = new List<string>();


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //var model=context.CatalogTypes.SingleOrDefault(c=>c.Id == Id);

            BaseDto<CatalogTypeDto> result=catalogTypeService.FindById(Id);

            if (result.IsSuccess)

            { CatalogType = mapper.Map<CatalogTypeViewModel>(result.Data); }
            else
            { Message = result.Message; }

            return View(CatalogType);
        }

        [HttpPost]
        public ActionResult Edit( CatalogTypeViewModel frombody) 
        {
            var model = mapper.Map<CatalogTypeDto>(frombody);
            var result = catalogTypeService.Edit(model);
            Message = result.Message;
            CatalogType = mapper.Map<CatalogTypeViewModel>(result.Data);
            return RedirectToAction("index","CategoryType","Admin");

        }

        //[HttpGet]
        //public ActionResult ShowChild(int ParentId)
        //{

        //    var CatalogList = catalogTypeService.GetList(ParentId, Page=1, PageSize=100);
        //    return View(CatalogList);
        //}

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var model = catalogTypeService.FindById(Id);
            if (model.IsSuccess)
                CatalogType = mapper.Map<CatalogTypeViewModel>(model.Data);
            

            return View(CatalogType);
        }


        [HttpPost]
        public IActionResult Delete( CatalogTypeViewModel fb)
        {
            var result = catalogTypeService.Remove(fb.Id);
            Message = result.Message;
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Message = result.Message; 
            
            }
            return NoContent();
        }
    }
}
