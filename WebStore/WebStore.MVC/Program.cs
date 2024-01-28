using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Core.Contracts;
using WebStore.Core.Services;
using WebStore.Infrastructure.Common;
using WebStore.Infrastructure.Data;
using WebStore.Infrastructure.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<WebStoreDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<WebStoreDbContext>()
    .AddDefaultTokenProviders()
    .AddUserManager<UserManager<ApplicationUser>>(); // Add UserManager service

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
