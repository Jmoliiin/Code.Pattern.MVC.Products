using Code.Pattern.Products.Data;
using Code.Pattern.Products.Factorys;
using Code.Pattern.Products.Handler;
using Code.Pattern.Products.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SqlContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddSingleton<IProductFactory, ProductFactory>();
builder.Services.AddSingleton<ICategoryFactory, CategoryFactory>();
builder.Services.AddSingleton<IDiscountFactory, DiscountFactory>();

builder.Services.AddScoped<IProductHandler, ProductHandler>();
builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();
builder.Services.AddScoped<IHelperHandler, HelperHandler>();
builder.Services.AddScoped<IDiscountHandler, DiscountHandler>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
