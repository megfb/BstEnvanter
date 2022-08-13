using BstEnvanter.Business.Abstract;
using BstEnvanter.Business.Concrete;
using BstEnvanter.Dal.Abstract;
using BstEnvanter.Dal.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
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






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.MapRazorPages();

app.Run();