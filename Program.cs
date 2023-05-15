using AppNotificactions.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();


var connectionString = builder.Configuration.GetConnectionString("DatosDb");
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddDbContextFactory<DatosDataContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA0NDM3NkAzMjMwMmUzNDJlMzBZZkNQVElRZzdLbFkyRmhGcldRL3VSUDBMeVEwL2k0R3JicDFFRGJqNUpBPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
