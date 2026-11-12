using System.Globalization;
using Microsoft.EntityFrameworkCore;
using maquillaje.Data;
using maquillaje.Services;

// Cultura es-MX: precios con punto decimal y fechas dd/MM/yyyy
try
{
    var cultura = new CultureInfo("es-MX");
    CultureInfo.DefaultThreadCurrentCulture = cultura;
    CultureInfo.DefaultThreadCurrentUICulture = cultura;
}
catch (CultureNotFoundException)
{
    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Los campos "no nulos" no se vuelven obligatorios solos; se usa [Required] donde hace falta
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// Sesión: guarda quién inició sesión (UsuarioId, Nombre, Rol) y el contador del carrito
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Conexión a SQL Server mediante Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

builder.Services.AddScoped<CorreoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Necesario para servir las imágenes que el administrador sube en tiempo de ejecución (wwwroot/uploads)
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
