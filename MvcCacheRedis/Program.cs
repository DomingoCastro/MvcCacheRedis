using MvcCacheRedis.Helpers;
using MvcCacheRedis.Repositories;
using MvcCacheRedis.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<HelperPathProvider>();
builder.Services.AddTransient<RepositoryProductos>();
string cnnCacheRedis = builder.Configuration.GetConnectionString("Redis");
builder.Services.AddTransient<ServiceCacheRedis>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = cnnCacheRedis;
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
    pattern: "{controller=Productos}/{action=Index}/{id?}");

app.Run();
