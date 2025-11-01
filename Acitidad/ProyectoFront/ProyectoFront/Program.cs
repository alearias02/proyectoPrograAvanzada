using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoFront.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//Establecer mi conexion de mysql
//Contexto maneja la informacion de la conexion
//public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
builder.Services.AddDbContext<AppDbContext>(

    options=>
           options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"))

    );


//"ConnectionStrings": {
//    "MySqlConnection": "server=45.88.196.5;port=3306;database=u484426513_pac325;user=u484426513_pac325;password=8CH86qC/"
//    }



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
