using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.GetMenuItem
{
    public interface IGetMenuItemService
    {
        List<MenuItemDto> Execute();

    }
}
