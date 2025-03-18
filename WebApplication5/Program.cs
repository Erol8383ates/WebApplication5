using Microsoft.EntityFrameworkCore;
using WebApplication5.Services;

var builder = WebApplication.CreateBuilder(args);

// Register ApplicationDbContext with dependency injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("./Admin/Printers");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();  // Map Razor Pages to routing
app.MapGet("/", () => Results.Redirect("./Admin/Printers"));

app.Run();
