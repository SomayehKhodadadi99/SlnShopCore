using Application.Catalogs.GetMenuItem;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndPoint.Models.ViewComponents
{
    //در مسیر شیر ویو باید یک ویو هم نام همین ویو کامپوننت ایجاد کنیم
    //GetMenuCategories.cshtm

    public class GetMenuCategories : ViewComponent
    {
        private readonly IGetMenuItemService _menuItemService;
        public GetMenuCategories(IGetMenuItemService getMenuItemService)
        {
                _menuItemService = getMenuItemService;
        }

        public IViewComponentResult Invoke()
        {
               var data= _menuItemService.Execute();
         
               return View(viewName: "GetMenuCategories", model: data);
           

        }
    }
}
