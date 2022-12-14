using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PizzeriaDbContextConnection"); 
    builder.Services.AddDbContext<PizzeriaDbContext>(options => options.UseSqlServer(connectionString)); 
    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PizzeriaDbContext>();


//ignora i cicli
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

//builder.Services.AddScoped<IDbPizzaRepository, InMemoryPizzaRepository>();
//builder.Services.AddScoped<IDbCategoriesRepository, InMemoryCateogoryRepository>();
//builder.Services.AddScoped<IDbIngredientsRepository, InMemoryIngredientRepository>();
//builder.Services.AddDbContext<PizzeriaDbContext>();
builder.Services.AddScoped<IDbPizzaRepository, DbPizzaRepository>();
builder.Services.AddScoped<IDbCategoriesRepository, DbCategoriesRepository>();
builder.Services.AddScoped<IDbIngredientsRepository, DbIngredientsRepository>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guest}/{action=Index}/{id?}");

app.Run();
