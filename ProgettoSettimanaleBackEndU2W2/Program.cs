using ProgettoSettimanaleBackEndU2W2.DAO;
using ProgettoSettimanaleBackEndU2W2.Services;
using ProgettoSettimanaleBackEndU2W2.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Recupera la stringa di connessione dalla configurazione
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registra i servizi con la stringa di connessione
builder.Services.AddScoped<IClienteDao>(provider => new ClienteDao(connectionString));
builder.Services.AddScoped<IServizioDao>(provider => new ServizioDao(connectionString));
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
