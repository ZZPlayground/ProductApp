using ProductApp.Application.Services;
using ProductApp.Application.Interfaces;
using ProductApp.Infrastructure;
using ProductApp.Infrastructure.Interfaces;
using ProductApp.Infrastructure.Repositories;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Register DapperContext as a singleton service
builder.Services.AddSingleton<DapperContext>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string is not configured.");
    }
    return new DapperContext(connectionString);
});

// Register IDbConnection to use DapperContext
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var context = sp.GetRequiredService<DapperContext>();
    return context.CreateConnection();
});

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
