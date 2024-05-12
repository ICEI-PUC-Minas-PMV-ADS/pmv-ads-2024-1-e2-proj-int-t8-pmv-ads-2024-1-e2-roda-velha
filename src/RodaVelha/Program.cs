using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RodaVelha.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RodaVelhaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RodaVelhaContext") ?? throw new InvalidOperationException("Connection string 'RodaVelhaContext' not found."),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // Número máximo de tentativas de reexecução
                maxRetryDelay: TimeSpan.FromSeconds(10), // Tempo máximo de espera entre tentativas
                errorNumbersToAdd: null); // Lista de erros adicionais considerados como falhas transitórias
        }
    ));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(options => {
    options.AccessDeniedPath = "/Users/AccesDenied/";
    options.LoginPath = "/Users/Login";
  });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Initialize the database seeding data if it's not already seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedUserData.Initialize(services);
    SeedEventData.Initialize(services);
    SeedLikeData.Initialize(services);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
