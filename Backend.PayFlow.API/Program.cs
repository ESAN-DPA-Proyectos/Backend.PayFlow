using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Core.Services;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Backend.PayFlow.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtener configuraci�n y cadena de conexi�n
var _config = builder.Configuration;
var connectionString = _config.GetConnectionString("DeveloperConnection");

// Registrar DbContext
builder.Services.AddDbContext<PayFlowDbContext>(options =>
    options.UseSqlServer(connectionString));


// Registrar servicios de aplicaci�n
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IHistorialSesionesService, HistorialSesionesService>();

builder.Services.AddTransient<ITransaccionesService, TransaccionesService>(); //reference to the service interface and implementation
builder.Services.AddTransient<ITransaccionesRepository, TransaccionesRepository>(); //reference to the repository interface and implementation para evitar 500 error

builder.Services.AddTransient<ISeguimientoTransaccionRepository, SeguimientoTransaccionRepository>();

builder.Services.AddScoped<ISeguimientoTransaccionService, SeguimientoTransaccionService>();

builder.Services.AddTransient<IHistorialValidacionesRepository, HistorialValidacionesRepository>();
builder.Services.AddScoped<IHistorialValidacionesService, HistorialValidacionesService>();


builder.Services.AddScoped<INotificacionRepository, NotificacionRepository>();
builder.Services.AddScoped<NotificacionService>();

builder.Services.AddTransient<IFondosRepository, FondosRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "PayFlow API",
        Version = "v1",
        Description = "API for managing transactions in PayFlow application."
    });
});


var app = builder.Build();

// Middleware y pipeline HTTP
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Soporte OpenAPI (opcional según librerías usadas)
    
    // Enable Swagger UI in development environment
    app.UseSwagger(); // Generación del JSON Swagger
    app.UseSwaggerUI(); // Interfaz gráfica de Swagger
}

app.UseAuthorization();

app.MapControllers();

app.Run();
