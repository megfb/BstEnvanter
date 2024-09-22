using BstEnvanter.Business.Abstract;
using BstEnvanter.Business.Concrete;
using BstEnvanter.Dal.Abstract;
using BstEnvanter.Dal.Concrete;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Extensions.Abstract;
using BstEnvanter.WebUI.Extensions.Concrete;
using BstEnvanter.WebUI.Identity;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddSession(option =>
{
    //Süre 1 dk olarak belirlendi
    option.IdleTimeout = TimeSpan.FromMinutes(60);
});

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    //CBSTSENVANTER\SQLEXPRESS
    options.UseSqlServer("Server=DESKTOP-2FDAH6B\\SQLEXPRESS;Database=BstEnvanter;Trusted_Connection=true");
}); builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders().AddPasswordValidator<CustomPasswordValidator>();
builder.Services.AddScoped<IBrandService, BrandManager>(); builder.Services.AddScoped<IBrandDal, BrandDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>(); builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<IModelService, ModelManager>(); builder.Services.AddScoped<IModelDal, ModelDal>();
builder.Services.AddScoped<IProductService, ProductManager>(); builder.Services.AddScoped<IProductDal, ProductDal>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>(); builder.Services.AddScoped<IDepartmentDal, DepartmentDal>();
builder.Services.AddScoped<ICLocationService, CLocationManager>(); builder.Services.AddScoped<ICLocationDal, CLocationDal>();
builder.Services.AddScoped<IPersonelService, PersonelManager>(); builder.Services.AddScoped<IPersonelDal, PersonelDal>();
builder.Services.AddScoped<ISexService, SexManager>(); builder.Services.AddScoped<ISexDal, SexDal>();
builder.Services.AddScoped<ICampusService, CampusManager>(); builder.Services.AddScoped<ICampusDal, CampusDal>();
builder.Services.AddScoped<IStatusService, StatusManager>(); builder.Services.AddScoped<IStatusDal, StatusDal>();
builder.Services.AddScoped<ICommonService, CommonManager>(); builder.Services.AddScoped<ICommonDal, CommonDal>();
builder.Services.AddScoped<ICpuService, CpuManager>(); builder.Services.AddScoped<ICpuDal, CpuDal>();
builder.Services.AddScoped<IGpuService, GpuManager>(); builder.Services.AddScoped<IGpuDal, GpuDal>();
builder.Services.AddScoped<IRamService, RamManager>(); builder.Services.AddScoped<IRamDal, RamDal>();
builder.Services.AddScoped<IHardDriveService, HardDriveManager>(); builder.Services.AddScoped<IHardDriveDal, HardDriveDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>(); builder.Services.AddScoped<IServiceDal, ServiceDal>();
builder.Services.AddScoped<IExtensions, ExportExcel>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;

});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/error/HttpStatusCodeHandler";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "BstEnvanterSecurityCookie",
        SameSite = SameSiteMode.Strict,
    };
});


var app = builder.Build();
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    SeedIdentity.Seed(userManager, roleManager);

}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
name: "default",
pattern: "{controller=account}/{action=login}/{id?}"
);

app.MapRazorPages();
app.Run();