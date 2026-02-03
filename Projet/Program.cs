/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Services (couche métier)
builder.Services.AddScoped<Projet.Services.IComputerService, Projet.Services.ComputerService>();
builder.Services.AddScoped<Projet.Services.IPrinterService, Projet.Services.PrinterService>();
builder.Services.AddScoped<Projet.Services.IAssignmentService, Projet.Services.AssignmentService>();
builder.Services.AddScoped<Projet.Services.IFaultService, Projet.Services.FaultService>();
builder.Services.AddScoped<Projet.Services.INotificationService,Projet.Services.NotificationService>();


// DAO (couche data) - AJOUTEZ CES LIGNES
builder.Services.AddScoped<IBesoinDao, BesoinDaoDB>();
//builder.Services.AddScoped<IDepartementDao, DepartementDaoDB>();
builder.Services.AddScoped<INotificationDao, NotificationDaoDB>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();*/
using Projet.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Services (couche métier)
builder.Services.AddScoped<Projet.Services.IComputerService, Projet.Services.ComputerService>();
builder.Services.AddScoped<Projet.Services.IPrinterService, Projet.Services.PrinterService>();
builder.Services.AddScoped<Projet.Services.IAssignmentService, Projet.Services.AssignmentService>();
builder.Services.AddScoped<Projet.Services.IFaultService, Projet.Services.FaultService>();
builder.Services.AddScoped<Projet.Services.INotificationService, Projet.Services.NotificationService>();


// DAO (couche data) - AJOUTEZ CES LIGNES
builder.Services.AddScoped<IBesoinDao, BesoinDB>();
//builder.Services.AddScoped<IDepartementDao, DepartementDaoDB>();
builder.Services.AddScoped<INotificationDao, NotificationDaoDB>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

