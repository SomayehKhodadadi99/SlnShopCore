using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{


    //ما فقط به آن اینتیتی هایی که می خواهیم این چهار فیلد اضافه شود ، این اتریبیوت را اضافه می کنیم
    [Auditable]
    public class User :IdentityUser
    {
        public string FullName { get; set; }
    }
}
