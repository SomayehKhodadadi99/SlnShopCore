using Application.Catalogs.CatalogBrand;
using Application.Catalogs.CatalogTypes.CrudService;
using Domain.Catalogs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.ViewModels.Catalogs
{
    public class AddNewCatalogItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام کاتالوگ")]
        [Required]
        [MaxLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "نوع کاتالوگ")]
        public int CatalogTypeId { get; set; }
        [Display(Name = "نام برند")]
        public int CatalogBrandId { get; set; }
        [Display(Name = "موجودی انبار")]
        public int AvailableStock { get; set; }
        [Display(Name = "حداقل مقدار آلارم ")]
        public int RestockThreshold { get; set; }
        [Display(Name = "بیشترین ظرفیت انبار")]
        public int MaxStockThreshold { get; set; }

        public IEnumerable<SelectListItem> CatalogTypeList { get; set; }

        public IEnumerable<SelectListItem> CatalogBrandList { get; set; }
    
    }
}
