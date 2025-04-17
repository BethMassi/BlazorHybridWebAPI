using BlazorHybridWebAPI.Shared.Services;
using BlazorHybridWebAPI.Web.Components;
using BlazorHybridWebAPI.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the BlazorHybridWebAPI.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorHybridWebAPI.Shared._Imports).Assembly);

//Expose the API endpoint for the weather service
app.MapGet("/api/weather", async (IWeatherService weatherService, DateTime startDate) =>
{
    var forecasts = await weatherService.GetWeatherForecastAsync(startDate);
    return Results.Ok(forecasts);
});

app.Run();
