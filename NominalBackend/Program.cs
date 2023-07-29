using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Categories.Repositories;
using NominalBackend.Domain.Categories.Services;
using NominalBackend.Domain.Images.Repositories;
using NominalBackend.Domain.Items.Repositories;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Domain.SubCategories.Repositories;
using NominalBackend.Domain.SubCategories.Services;
using NominalBackend.Domain.Wishlists.Repositories;
using NominalBackend.Domain.Wishlists.Services;
using NominalBackend.Generics;
using NominalBackend.Persistence;
using NominalBackend.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
builder.Services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
builder.Services.AddScoped<IWishlistService, WishlistService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
