using System;
using System.IO;
using Projet.Data;
using Projet.Services;

var builder = WebApplication.CreateBuilder(args);

// Définit |DataDirectory| vers le dossier "Data" du projet (utile pour AttachDbFilename)
AppContext.SetData("DataDirectory", Path.Combine(builder.Environment.ContentRootPath, "Data"));

// Add services to the container.
builder.Services.AddRazorPages();

// DbFactory lit la connection string depuis appsettings.json
builder.Services.AddSingleton<DbFactory>();

// Services du module Maintenance (Dev 5)
builder.Services.AddScoped<IPanneService, PanneService>();
builder.Services.AddScoped<IInterventionService, InterventionService>();
builder.Services.AddScoped<IConstatService, ConstatService>();
builder.Services.AddScoped<IDecisionService, DecisionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();          
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
