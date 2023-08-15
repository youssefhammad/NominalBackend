using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NominalBackend.Domain.ApplicationUser.Models;
using NominalBackend.Domain.Categories.Repositories;
using NominalBackend.Domain.Categories.Services;
using NominalBackend.Domain.Engineers.Repositories;
using NominalBackend.Domain.Images.Repositories;
using NominalBackend.Domain.Images.Services;
using NominalBackend.Domain.Items.Repositories;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Domain.SubCategories.Repositories;
using NominalBackend.Domain.SubCategories.Services;
using NominalBackend.Domain.WebSiteStaticInfo.StaticData.Repositories;
using NominalBackend.Domain.WebSiteStaticInfo.StaticData.Services;
using NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Repositories;
using NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Services;
using NominalBackend.Domain.Wishlists.Repositories;
using NominalBackend.Domain.Wishlists.Services;
using NominalBackend.Generics;
using NominalBackend.Persistence;
using NominalBackend.UnitOfWork;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
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

builder.Services.AddScoped<IDimensionRepository, DimensionRepository>();
builder.Services.AddScoped<IDimensionService, DimensionService>();

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IColorRepository,ColorRepository>();
builder.Services.AddScoped<IColorService, ColorService>();

builder.Services.AddScoped<IEngineerRepository, EngineerRepository>();
builder.Services.AddScoped<IEngineerService, EngineerService>();

builder.Services.AddScoped<IEngineerPortfolioRepository, EngineerPortfolioRepository>();
builder.Services.AddScoped<IEngineerPortfolioService, EngineerPortfolioService>();

builder.Services.AddScoped<IStaticDataRepository, StaticDataRepository>();
builder.Services.AddScoped<IStaticDataService, StaticDataService>();

builder.Services.AddScoped<IStaticImageRepository, StaticImageRepository>();
builder.Services.AddScoped<IStaticImageService, StaticImageService>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
