using Microsoft.EntityFrameworkCore;
using WorkWebApp;
using WorkWebApp.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();


// used for the DB 
builder.Services.AddDbContext<UserDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("VagtplanDB"))
);

builder.Services.AddTransient<IUser,Userdetail>();

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();


var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "user",
    pattern: "{controller=Admin}/{action=Index}/{record_id?}");

app.MapControllerRoute(
    name: "shift",
    pattern: "{controller=Shift}/{action=Index}/{record_id?}");

app.MapRazorPages();
app.MapControllers();

app.MapControllers();

app.Run();