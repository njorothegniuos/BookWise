using BookWise.Web.Data;
using BookWise.Web.Data.BookModule;
using BookWise.Web.Services;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<BookService>();
builder.Services
               .AddScoped<IAccountService, AccountService>()
               .AddScoped<IAlertService, AlertService>()
               .AddScoped<IHttpService, HttpService>()
               .AddScoped<ILocalStorageService, LocalStorageService>();

// configure http client
builder.Services.AddScoped(x => {
    var apiUrl = new Uri(builder.Configuration["apiUrl"]);

    return new HttpClient() { BaseAddress = apiUrl };
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
