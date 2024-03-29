﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Contexts;
using Domain.Attributes;
using Domain.Users;
using Domain.Catalogs;
using Persistence.EntityConfigurations;

namespace Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        //کامنت می شود چون در درون آیدنتیتی می خوام از 
        //user
        //استفاده کنم
        //public DbSet<User>  Users { get; set; }


        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>().Property<DateTime?>("InsertTime");
            //builder.Entity<User>().Property<DateTime?>("UpdateTime");

            //اینجا آن فیلد ها را که می خواهیم به هر اینتیتی که این اتیبوت را دارد اضافه می کنیم
            //اگر بیایینم کلاس بزاریم و آن چند فیلد را در آن بنویسیم مجبوریم همیشه ازان کلاس اینهریت کنیم که نمی خواهیم
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    //insert time va isRemove ,null able nistan
                    //pas nemitoone khali bashan moghe seed
                    //bayad has default value bedim
                    //ama baghye mohem nistan chon nullable hastan

                    builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now); 
                    builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false); ;
                }
            }

            //کانفیگ هاایی که در لایه ی دیتا بیس گفتیم ینی همین جا
            //اینجا اپلای می کنیم
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());

            DataBaseContextSeed.CatalogSeed(builder);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            //وقتی می خواهم در آن مقادیز اضافه کنم
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                p.State == EntityState.Added ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var RemoveTime = entityType.FindProperty("RemoveTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                if (item.State == EntityState.Added && inserted != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified && updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                }
            }
            return base.SaveChanges();
        }
    }
}

