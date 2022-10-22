using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");


// Configure Services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MusicStoreEntities>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<SampleData>();

var app = builder.Build();
using var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<SampleData>();

seeder.Seed();

// Configure

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
