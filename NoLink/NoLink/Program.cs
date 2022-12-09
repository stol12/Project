using NoLink.Data;
using NoLink.Extensions;
using NoLink.Services.FirmServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoLink.Services.UserService;
using NoLink.Services.ArticleServices;
using NoLink.Services.FormFIleServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Context>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("Context")));

builder.Services.AddTransient<IFirmService, FirmService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IFormFileService, FormFileService>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

});

builder.Services.ConfigureApplicationCookie(opt =>
{ 
    opt.Cookie.HttpOnly = true;
    opt.LoginPath = "/Account/Login";

});

var app = builder.Build();

app.PrepareDatabase();

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
app.UseAuthentication();

app.MapDefaultControllerRoute();

app
    .UseHttpsRedirection()
    .UseRouting()
    .UseEndpoints(endpoints =>
{
        endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

        endpoints.MapRazorPages();
});

app.Run();
