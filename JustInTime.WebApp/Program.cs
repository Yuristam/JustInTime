using JustInTime.DAL.Database.Contexts;
using JustInTime.WebApp.Areas;
using JustInTime.WebApp.Areas.Identity.Data;
using JustInTime.WebApp.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");


builder.Services.AddTransient<IShortedUserController, PersonUserController>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NotesDbContext>(ctx => ctx.UseLazyLoadingProxies());
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddRazorPages();

builder.Services.AddIdentity<JustInTimeUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();
/*
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<JustInTimeUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();
builder.Services.AddRazorPages();

*/


// this is connection string (it connects c# code to the database)
builder.Services.AddDbContext<NotesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesConnectionString")/*connectionString*/);
});

/*
// Add services to the container.
builder.Services.AddControllersWithViews();*/
/*
#region Authorization

AddAuthorizationPolicies();

#endregion*/
/*
AddScoped();

*/
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

app.UseEndpoints(e =>
{
    e.MapRazorPages();
    e.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

});


app.Run();
/*
void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.GroupAdmin));
        options.AddPolicy(Constants.Policies.RequireMember, policy => policy.RequireRole(Constants.Roles.GroupMember));
    });
}

void AddScoped()
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}*/