using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(o => o.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Repositories
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<IHallRepository, HallRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<IScreeningRepository, ScreeningRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();

// Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IHallService, HallService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IScreeningService, ScreeningService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var rm = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var um = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    foreach (var role in new[] { "Admin", "User" })
        if (!await rm.RoleExistsAsync(role))
            await rm.CreateAsync(new IdentityRole(role));

    const string adminEmail = "admin@thefilmvault.ro";
    var admin = await um.FindByEmailAsync(adminEmail);
    if (admin == null)
    {
        admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        await um.CreateAsync(admin, "Admin@1234!");
        await um.AddToRoleAsync(admin, "Admin");
    }
}

app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();