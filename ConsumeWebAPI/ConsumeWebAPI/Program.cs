using ConsumeWebAPI.Repositories;
using ConsumeWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc()
               .AddRazorPagesOptions(options => {
                   options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
               }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

    builder.Services.AddSingleton<IUserManegemetService, UserManegementService>();
    builder.Services.AddSingleton<IUserManegementRepository, UserManegementRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=branch}/{action=index}/{id?}");

app.Run();
