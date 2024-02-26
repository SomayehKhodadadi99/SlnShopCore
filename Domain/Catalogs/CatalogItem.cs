using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        //موجودی انبار
        public int AvailableStock { get; set; }
        //موجودی انبار ب کمتر ازین رسید آلارم بده
        public int RestockThreshold { get; set; }
        //بیشترین مقدار ظرفیت انبار
        public int MaxStockThreshold { get; set; }


        //هر محصول شامل ان ویزگی می باشد
        public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }

        //هر محصول دارای چندین عکس می بااشد

        public ICollection<CatalogItemImage> CatalogItemImages { get; set; }

    }
}
