using RubikBook.Core.Interface;
using RubikBook.Core.Services;
using RubikBook.Database.Context;

var builder = WebApplication.CreateBuilder(args);


#region Scope
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddMvc();
builder.Services.AddScoped<IAccount, AccountService>();
builder.Services.AddScoped<IAuthor, AuthorService>();
builder.Services.AddScoped<IPay, PayService>();
builder.Services.AddScoped<IGroup, GroupService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IProfile, ProfileService>();
builder.Services.AddScoped<IPublisher, PublisherService>();
builder.Services.AddScoped<IOrders, OrderService>();
builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
#endregion


const string scheme = "rubikbook";
builder.Services.AddAuthentication(scheme).AddCookie(scheme, option =>
{
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/Login";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);//Not For Real Host
});

var app = builder.Build();

app.UseStaticFiles(); //اجاره دسترسی به پوشه ها را میدهد
app.UseRouting(); //ساختار آدرس دهی که پایین تعریف شده است 

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "area",
        pattern: "{area:exists}/{controller=Panel}/{action=Index}/{id?}"
);

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}");

});





app.Run();
