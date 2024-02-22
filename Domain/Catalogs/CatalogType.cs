using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int? ParentCatalogTypeId { get; set; }
        //اطلاعات ردیف پدر
        public CatalogType ParentCatalogType { get; set; }

        //لیست فرزندان
        public ICollection<CatalogType> Children { get; set; }
    }
}
