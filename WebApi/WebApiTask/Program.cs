using Microsoft.EntityFrameworkCore;
using WebApiTask.Infrastructure;
using WebApiTask.Mapping;
using WebApiTask.Models.DbModels;
using WebApiTask.Models.DtoModels;
using WebApiTask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindDataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBaseService<CategoryDto>, BaseService<Category, CategoryDto>>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
