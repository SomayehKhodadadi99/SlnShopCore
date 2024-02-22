using Application.DTOGeneral;
using Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Catalogs;
using AutoMapper;
using Commons;
namespace Application.Catalogs.CatalogTypes.CrudService
{
    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public CatalogTypeService(IDataBaseContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            //Map<distination>(source)
            var model = mapper.Map<CatalogType>(catalogType);

            context.CatalogTypes.Add(model);

            context.SaveChanges();

            return new BaseDto<CatalogTypeDto>
               (
               mapper.Map<CatalogTypeDto>(model),
               true,
               new List<string> { $"تایپ {model.Type}  با موفقیت در سیستم ثبت شد" }

             );
        }

        //ورودی همان سورس ماست
        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var model = context.CatalogTypes.SingleOrDefault(p => p.Id == catalogType.Id);

            //Map(source,distination)
            mapper.Map(catalogType, model);

            context.SaveChanges();

            return new BaseDto<CatalogTypeDto>
              (
                 mapper.Map<CatalogTypeDto>(model)
               , true,
                new List<string> { $"تایپ {model.Type} با موفقیت ویرایش شد" }
              );
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            var data = context.CatalogTypes.Find(Id);

            //<distination>(source)
            var result = mapper.Map<CatalogTypeDto>(data);

            return new BaseDto<CatalogTypeDto>(result, true, null);

        }

        public BaseDto Remove(int Id)
        {
            var catalogType = context.CatalogTypes.Find(Id);
            context.CatalogTypes.Remove(catalogType);
            context.SaveChanges();
            return new BaseDto
            (
             true,
             new List<string> { $"ایتم با موفقیت حذف شد" }

       );
        }

        public PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
        
        
        {
            int totalCount = 0;

            //var x=context.CatalogTypes.AsQueryable().ToList();
            //var x = context.CatalogTypes.AsQueryable().PagedResult();

            //IQueryable<T> PagedResult

            //model   --> CatalogType

            var model = context.CatalogTypes
                .Where(p => p.ParentCatalogTypeId == parentId).AsQueryable()
                   .PagedResult(page, pageSize, out totalCount);

            //CatalogType ---> CatalogTypeListDto

            //ProjectTo<Distination>(source)   ----> source IQueryable

            var result = mapper.ProjectTo<CatalogTypeListDto>(model).ToList();

            return new PaginatedItemsDto<CatalogTypeListDto>(page, pageSize, totalCount, result);

        }
    }
}
