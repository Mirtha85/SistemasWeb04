using Microsoft.EntityFrameworkCore;
using SistemasWeb01.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

using SistemasWeb01;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BdContexTiendaTecnoBoliviaScConnection") ?? throw new InvalidOperationException("Connection string 'BdContexTiendaTecnoBoliviaScConnection' not found.");

// Add services to the container.
//Add ignoring infinitive cycles for models objects serialize
builder.Services.AddControllersWithViews().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<InterfazCategoria, RepositorioCategoria>();
builder.Services.AddScoped<InterfazProducto, RepositorioProducto>();

builder.Services.AddScoped<InterfazOrder, RepositorioOrder>();
builder.Services.AddScoped<InterfazContacto, RepositorioContacto>();

builder.Services.AddScoped<InterfazShoppingCart, RepositorioShoppingCart>(sp => RepositorioShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Conexion a la base de datos
builder.Services.AddDbContext<BdContexTiendaTecnoBoliviaSc>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>(
    //options => options.SignIn.RequireConfirmedAccount = true
    ).AddEntityFrameworkStores<BdContexTiendaTecnoBoliviaSc>();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Producto}/{action=Mensajepro}/{id?}");

app.MapRazorPages();
app.MapBlazorHub();

app.Run();

