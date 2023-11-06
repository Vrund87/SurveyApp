using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using SurveyWebApp.Data;
using SurveyWebApp.Services;
using System.Security.Authentication;
using System.Xml.Xsl;
using MongoDB.Driver;
using SurveyWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<SurveyDBSettings>(
    builder.Configuration.GetSection(nameof(SurveyDBSettings)));

builder.Services.AddSingleton<ISurveyDBSettings>(sp =>
    sp.GetRequiredService<IOptions<SurveyDBSettings>>().Value);

//builder.Services.AddSingleton<IMongoClient>(s =>
//    new MongoClient(builder.Configuration.GetValue<string>("SurveyDBSettings:ConnectionString")));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetValue<string>("SurveyDBSettings:ConnectionString");
    var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
    settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
    return new MongoClient(settings);
});

builder.Services.AddSingleton<ICallAPI, CallAPI>();


var app = builder.Build();

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
