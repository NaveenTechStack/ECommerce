using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.DBInitializer;
using ECommerce.DataAccess.Repository;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Service;
using ECommerce.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseInMemoryDatabase("DemoDatabase"));

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.Configure<RazorPaySettings>(builder.Configuration.GetSection("RazorPay"));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

var cultureInfo = new CultureInfo("en-IN");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddAuthentication().AddFacebook(Options =>
{
    Options.AppId = "1333871568317386";
    Options.AppSecret = "9bf63851464f8a5aa780ae61b24495df";
});

builder.Services.AddAuthentication().AddMicrosoftAccount(Options =>
{
    Options.ClientId = "d77f351e-84cc-439c-a7d6-90a90df72a81";
    Options.ClientSecret = "Qhq8Q~RZnlLWOnQ7U9uA_4dzs6obVWSTnnw6KdpN";
});


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(100);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });


builder.Services.AddRazorPages();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<RazorpayService>();
builder.Services.AddScoped<IDbInitializer,DbInitializer>();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
SeedDatabase();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using(var scope = app.Services.CreateScope())
    {
       var dbInitializer =  scope.ServiceProvider.GetRequiredService<IDbInitializer>();
       dbInitializer.Initialize();
    }
}