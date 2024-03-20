using Microsoft.EntityFrameworkCore;
using soft20181_starter.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Create Session For Authentication Work
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    // Configure session options here
    options.Cookie.Name = ".EventXplorer.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Adjust the session timeout as needed
    //options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});
//-----------------------------------------------------

builder.Services.AddRazorPages();

builder.Services.AddDbContext<DBHelper>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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

app.UseSession();  // For Session Important

app.UseAuthorization();

app.MapRazorPages();

app.Run();
