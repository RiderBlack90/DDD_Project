using Application.Interfaces;
using Application.OpenApp;
using Domain.Interfaces.Generics;
using Domain.Interfaces.IProducts;
using Domain.Interfaces.IServices;
using Domain.Services;
using ECommerce_Web.Data;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Interfaces.ICompraUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var connectionString2 = builder.Configuration.GetConnectionString("ContextBaseConnection") ?? throw new InvalidOperationException("Connection string 'ContextBaseConnection' not found.");
builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(connectionString2));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddControllersWithViews();

// REPOSITORY
builder.Services.AddScoped(typeof(IGeneric<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<ICompraUsuario,CompraUsuarioRepository>();

// APPLICATION
builder.Services.AddScoped<InterfaceProductApp, ProductApp>();
builder.Services.AddScoped<InterfaceCompraUsuarioApp, CompraUsuarioApp>();

// DOMAIN
builder.Services.AddScoped<IServicesProduct, ServiceProduct>();
builder.Services.AddScoped<IServiceCompraUsuario, ServiceCompraUsuario>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
