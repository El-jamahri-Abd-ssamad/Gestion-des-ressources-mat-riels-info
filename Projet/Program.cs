
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<Projet.Services.IComputerService, Projet.Services.ComputerService>();
builder.Services.AddScoped<Projet.Services.IPrinterService, Projet.Services.PrinterService>();
builder.Services.AddScoped<Projet.Services.IAssignmentService, Projet.Services.AssignmentService>();
builder.Services.AddScoped<Projet.Services.IFaultService, Projet.Services.FaultService>();

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

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// Register maintenance (Dev 5) service
builder.Services.AddScoped<Projet.Services.IFaultService, Projet.Services.FaultService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
*/
