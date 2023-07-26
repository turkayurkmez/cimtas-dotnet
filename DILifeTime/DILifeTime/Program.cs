using DILifeTime.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*
 *   1. Singleton: Sadece 1 instance al. Hep onu kullan
 *   2. Transient Her seferinde instance al. Hep farklı kullan.
 *   3. Scoped: Instance başka bir nesnenin içinde olduğu sürece aynı o nesne dispose olursa farklı olsun.
 */

builder.Services.AddSingleton<ISingletonGuid, SingletonGuid>();
builder.Services.AddTransient<ITransientGuid, TransientGuid>();
builder.Services.AddScoped<IScopedGuid, ScopedGuid>();

builder.Services.AddScoped<GuidService>();

builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
{
    //http://www.cimtas.com.tr
    //https://www.cimtas.com.tr
    //http://hr.cimtas.com.tr
    //http://www.cimtas.com.tr:8075

    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

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


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
