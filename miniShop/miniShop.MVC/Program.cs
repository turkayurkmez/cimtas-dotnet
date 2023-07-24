using miniShop.Application.Services;
using miniShop.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container (IoC).
/*
 *   1. Singleton: Sadece 1 instance al. Hep onu kullan
 *   2. Transient Her seferinde instance al. Hep farklı kullan.
 *   3. Scoped: Instance başka bir nesnenin içinde olduğu sürece aynı o nesne dispose olursa farklı olsun.
 */
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, FakeProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, FakeCategoryRepository>();

builder.Services.AddSession();

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

app.UseSession();

app.UseAuthorization();



app.MapControllerRoute(name: "categoryFilter",
                       pattern: "Kategori/{catId?}",
                       defaults: new { controller = "Home", action = "Index" }
                       );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
