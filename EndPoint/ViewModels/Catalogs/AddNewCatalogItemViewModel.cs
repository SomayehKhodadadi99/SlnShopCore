using Application.Catalogs.CatalogBrand;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Catalogs.CatalohItems.AddNewCatalogItem;
using Domain.Catalogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        [Required]
        public int Price { get; set; }
        [Display(Name = "نوع کاتالوگ")]
        [Required]
        public int CatalogTypeId { get; set; }
        [Display(Name = "نام برند")]
        [Required]
        public int CatalogBrandId { get; set; }
        [Display(Name = "موجودی انبار")]
        [Required]
        public int AvailableStock { get; set; }
        [Display(Name = "حداقل مقدار آلارم ")]
        [Required]
        public int RestockThreshold { get; set; }
        [Display(Name = "بیشترین ظرفیت انبار")]
        [Required]
        public int MaxStockThreshold { get; set; }
        
        public IEnumerable<SelectListItem> CatalogTypeList { get; set; }

        public IEnumerable<SelectListItem> CatalogBrandList { get; set; }

        public List<AddNewCatalogItemFeature_dto> Features { get; set; }
        public List<AddNewCatalogItemImage_Dto> ListSrcImages { get; set; }

    }
}
