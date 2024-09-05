using HYR_Blog.CoreLayer.FacadPattern.FacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.FacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Services.FileManageServices;
using HYR_Blog.CoreLayer.Services.ProductServices.Commands;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using HYR_Blog.CoreLayer.Services.UserService.Queries;
using HYR_Blog.CoreLayer.Services.ProductServices.Queries;
using HYR_Blog.CoreLayer.Services.CategoryServices.Queries;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();



//builder.Services.AddRazorPages(option=>
//option.Conventions.AuthorizeAreaPage("Admin","/index"));
//FacadPattern
builder.Services.AddSingleton<ISingletonFacadPattern, SingletonFacadPattern>();
builder.Services.AddScoped<IScopeFacadPattern, ScopeFacadPattern>();
builder.Services.AddSingleton<ITransientFacadPattern, TransientFacadPattern>();


//UiFacadPattern
builder.Services.AddScoped<IUiScopeFacadPattern, UiScopeFacadPattern>();

//other services
builder.Services.AddScoped<IFileManageService, FileManageService>();


// Injection Services
builder.Services.AddScoped<IAddProductVisitService, AddProductVisitService>();
builder.Services.AddScoped<IGetAllProductUserBuyService, GetAllProductUserBuyService>();
builder.Services.AddScoped<IGetProductService, GetProductService>();
builder.Services.AddScoped<IGetIndexCategoryService, GetIndexCategoryService>();




builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(opt =>
{
    opt.LoginPath = "/user/login";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.LogoutPath = "/user/logout";
    opt.AccessDeniedPath = "/";
    opt.Cookie.Name = "HyrUser";
});

builder.Services.AddAuthorization(option =>
option.AddPolicy("AdminPolicy",policy=>policy.RequireRole("Admin")));



builder.Services.AddDbContext<HYR_Blog.DataLayer.Context.HyrDbContext>(
    option => option.UseSqlServer("Server=.;Database=HYR_BlogDb;Integrated Security=true;MultipleActiveResultSets=true;trustServerCertificate=true;")
);

//builder.Services.AddDbContext<HyrDbContext>(option =>
//option.UseSqlServer(builder.Configuration.GetConnectionString("DeveloperConnection"))
//);

builder.Services.AddAntiforgery(option =>
    option.HeaderName = "XSRF-TOKEN");
builder.Services.AddRazorPages();



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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
