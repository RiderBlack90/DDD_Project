using Application.Interfaces;
using Application.OpenApp;
using Domain.Interfaces.Generics;
using Domain.Interfaces.IProducts;
using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories;
using Infra.Repositories.Generics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// ==========================
// DATABASE (apenas UMA connection string)
// ==========================
services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// ==========================
// IDENTITY (apenas UM tipo de user)
// ==========================
services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ContextBase>();

// ==========================
// MVC / RAZOR
// ==========================
services.AddControllersWithViews();
services.AddRazorPages();

// ==========================
// REPOSITÓRIO
// ==========================
services.AddScoped(typeof(IGeneric<>), typeof(GenericRepository<>));
services.AddScoped<IProduct, ProductRepository>();

// ==========================
// APLICAÇÃO
// ==========================
services.AddScoped<InterfaceProductApp, ProductApp>();

// ==========================
// DOMÍNIO
// ==========================
services.AddScoped<IServicesProduct, ServiceProduct>();

var app = builder.Build();

// ==========================
// PIPELINE
// ==========================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
