using Microsoft.EntityFrameworkCore;
using SistemasWeb01.Models;
using SistemasWeb01;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

//conexion
builder.Services.AddDbContext<BethesdaPieShopDbContext>(options => {
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:BethesdaPieShopDbContextConnection"]);
});


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
DbInitializer.Seed(app);
app.Run();
