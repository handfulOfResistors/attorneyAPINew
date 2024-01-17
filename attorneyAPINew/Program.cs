using attorneyApi.Repository;
using attorneyApi.Repository.Interface;
using attorneyAPINew.Models;
using attorneyAPINew.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<attorneyPetrovicContext>(x=>x.UseSqlServer(connectionString));
builder.Services.AddScoped<ICourtCaseRepository, CourtCaseRepository>();
builder.Services.AddScoped<ICourtCodeRepository, CourtCodeRepository>();


// Konfiguracija Serilog loggera
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("app.log", rollingInterval: RollingInterval.Day) 
    .CreateLogger();

builder.Host.UseSerilog();




builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
    //Promeni samo na format koj tebi odgovara..
    options.SerializerSettings.DateFormatString = "dd'.'MM'.'yyyy./''HH':'mm";
    //"yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"
});

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
