using Microsoft.EntityFrameworkCore;
using SistemasWeb01.Models;
using SistemasWeb01;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<InterfazCategoria, RepositorioCategoria>();

builder.Services.AddScoped<InterfazProducto, RepositorioProducto>();

//conexion
builder.Services.AddDbContext<BdContexTiendaTecnoBoliviaSc>(options => {
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:BdContexTiendaTecnoBoliviaScConnection"]);
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
    pattern: "{controller=Producto}/{action=Mensajepro}/{id?}");

app.Run();
