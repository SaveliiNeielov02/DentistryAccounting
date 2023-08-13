using Dentistry.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ModelDBContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}*/
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=PatientsCatalog}/{action=PatientsCatalog}");

app.MapControllerRoute(
   name: "PatientAdditionPage",
   pattern: "/PatientAddition",
   defaults: new { controller = "PatientAddition", action = "PatientAddition" });

app.MapControllerRoute(
   name: "AddPatient",
   pattern: "/PatientAddition/AddPatient",
   defaults: new { controller = "PatientAddition", action = "AddPatient" });

app.MapControllerRoute(
   name: "PatientPage",
   pattern: "/PatientsCatalog/{ID}",
   defaults: new { controller = "PatientsCatalog", action = "PatientPage" });

app.MapControllerRoute(
   name: "GetReception",
   pattern: "/PatientPage/GetReceptions/{receptionsID}",
   defaults: new { controller = "PatientPage", action = "GetReceptions" });

app.MapControllerRoute(
   name: "GetType",
   pattern: "/PatientPage/GetType/{typeID}",
   defaults: new { controller = "PatientPage", action = "GetType" });




app.Run();
