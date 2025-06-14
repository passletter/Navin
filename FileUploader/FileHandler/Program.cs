using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
 builder.Host.UseSerilog(); 
 

builder.Services.AddControllersWithViews();

// Register custom services
builder.Services.AddSingleton<IFileEventBus, FileEventBus>();
builder.Services.AddSingleton<FileWatcherService>();
builder.Services.AddSingleton<FileHandlers>();
builder.Services.AddHostedService<FileWatcherHostedService>();

var app = builder.Build();

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
