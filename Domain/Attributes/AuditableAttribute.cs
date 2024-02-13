using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Attributes
{
    //به روش رفلکشن
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditableAttribute : Attribute
    {
    }
}
