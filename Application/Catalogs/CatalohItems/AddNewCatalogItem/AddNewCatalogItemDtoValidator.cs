using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Catalogs.CatalohItems.AddNewCatalogItem
{
    public class AddNewCatalogItemDtoValidator : AbstractValidator<AddNewCatalogItemDto>
    {
        public AddNewCatalogItemDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("نام کاتالوگ اجباری است");
            RuleFor(x => x.Name).Length(2, 100);
            RuleFor(x => x.Description).NotNull().WithMessage("توضیحات نمی تواند خالی باشد");
            RuleFor(x => x.AvailableStock).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Price).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Price).NotNull();
        }
    }
}
