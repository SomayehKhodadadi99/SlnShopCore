using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalogs
{
    [Auditable]
    //کلاس ویژگی های اون محصول
    //هر ویژگی برای یک محصول است
    //مشخصات - گوشی موبایل 
    // کی ولیو
    //هر کدوم ازین کی ولیو برای یک گروه می باشد
    public class CatalogItemFeature
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatlogItemId { get; set; }
    }
}
