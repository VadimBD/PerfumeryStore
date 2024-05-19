

using Microsoft.AspNetCore.Identity;
using PerfumeryStore.Models;
using PerfumeryStore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using PerfumeryStore.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppIdentityDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AppIdentityDBContextConnection' not found.");

builder.Services.AddDbContext<AppIdentityDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<PerfumeryStoreUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AppIdentityDBContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductRepository, FakeProductRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp=>SessionCart.GetCart(sp));
builder.Services.AddScoped<IOrderRepository, FakeOrderRepository>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddMvc();
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);

    options.LoginPath = "/Identity/Account/Login";
    options.SlidingExpiration = true;
});

var app = builder.Build();
app.UseSession();


app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}
else
{


    app.UseExceptionHandler("/Error");
}
app.UseRouting();
app.MapRazorPages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();