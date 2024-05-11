

using PerfumeryStore.Models;
using PerfumeryStore.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductRepository, FakeProductRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp=>SessionCart.GetCart(sp));

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddMvc();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();