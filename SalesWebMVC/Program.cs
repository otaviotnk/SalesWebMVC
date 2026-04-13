using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesWebMVC.Data;
using SalesWebMVC.Interfaces;
using SalesWebMVC.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SalesWebMVCContext");
builder.Services.AddDbContext<SalesWebMVCContext>(options =>
    options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly("SalesWebMVC")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ISalesRecordService, SalesRecordService>();

var app = builder.Build();

var cultureInfo = CultureInfo.GetCultureInfo("pt-BR");

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultureInfo),
    SupportedCultures = [cultureInfo],
    SupportedUICultures = [cultureInfo]
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetRequiredService<SeedingService>().Seed();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
