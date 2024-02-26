using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogItemImage
    {
        public int Id { get; set; }
        //هر عکس یه آدرس داره
        public string Src { get; set; }

        // هر عکس واسه یک محصول است
        public CatalogItem CatalogItem { get; set; }
        public int CatlogItemId { get; set; }

    }
}
