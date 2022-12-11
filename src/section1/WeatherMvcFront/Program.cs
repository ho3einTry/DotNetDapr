using System.Diagnostics;
using System.Reflection;
using Dapr.Client;
using WeatherMvcFront.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddRazorPages().AddDapr();

var projectName = Assembly.GetEntryAssembly()!.GetName().Name;


services.AddSingleton<HttpClient>(p => DaprClient.CreateInvokeHttpClient(projectName));
services.AddSingleton<IWeatherClient, WeatherClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();

app.Run();