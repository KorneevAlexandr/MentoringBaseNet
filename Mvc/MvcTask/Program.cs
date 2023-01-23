using Microsoft.EntityFrameworkCore;
using MvcTask.Infrastructure;
using MvcTask.Mapping;
using MvcTask.Models.DbModels;
using MvcTask.Models.DtoModels;
using MvcTask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBaseService<CategoryDto>, BaseService<Category, CategoryDto>>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
