using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JustInTime.WebApp.Areas.Identity.Data;
using JustInTime.DAL.Database.Contexts;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<JustInTimeUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityContext>();

/*
builder.Services.AddIdentity<JustInTimeUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();*/



// this is connection string (it connects c# code to the database)
builder.Services.AddDbContext<NotesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesConnectionString"));           // this is connection string for notes
    /*options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));*/   // this is connection string for big notes lists
});



// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
