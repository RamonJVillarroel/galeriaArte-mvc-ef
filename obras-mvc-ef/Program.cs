using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using obras_mvc_ef.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GaleriaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services
    .AddDefaultIdentity<IdentityUser>(
    options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireNonAlphanumeric = false;
        options.User.RequireUniqueEmail = true;
    }
    )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GaleriaDbContext>();
builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(o =>

{

    o.ExpireTimeSpan = TimeSpan.FromMinutes(60);

    o.SlidingExpiration = true;

    o.LoginPath = "/Identity/Account/Login";

    o.AccessDeniedPath = "/Identity/Account/AccessDenied";

});
var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GaleriaDbContext>();
    DbSeeder.Seed(context);
}*/


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

app.Run();
