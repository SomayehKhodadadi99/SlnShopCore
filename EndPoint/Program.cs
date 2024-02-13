﻿using Application.Catalogs.CatalogTypes.CrudService;
using Infrastructure;
using Infrastructure.MappingProfile;
using Microsoft.EntityFrameworkCore;

using Persistence.Contexts;
//using Infrastructure.IdentityConfigs;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();

//----------------------------------------connection------------------------------------
builder.Services.AddDbContext<DataBaseContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddDbContext<IdentityDatabaseContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
//---------------------------------------------------------------------------------------

// Add services to the container.
//service ها رو زیر هم بنویس 
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityService(configuration);
builder.Services.AddAuthorization();

//با اضافه کردن پکیج اتومپر دیپند
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));


builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/Account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});

//builder.Services.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();