using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOGeneral
{
    public class CatalogTypeListDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        // تعداد فرزندان
        public int ChildrenCount { get; set; }
    }
}
