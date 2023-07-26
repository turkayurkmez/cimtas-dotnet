using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using miniShop.Application.MapProfile;
using miniShop.Application.Services;
using miniShop.Infrastructure.Data;
using miniShop.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<MiniShopDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MapProfileForEntities));
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = "cimtas.mobil",
                        ValidIssuer = "cimtas.com.tr",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-kripto-icin-onemli"))


                    };

                });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//kendi middleware'inizi yazabilirsiniz. En basit yöntemi aşağıdaki gibi. 
//1. HttpContext: gelen http isteği hakkında tüm konsept
//2. Sonraki middleware:
app.Use(async (context, next) =>
{

    await next();

});


app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
