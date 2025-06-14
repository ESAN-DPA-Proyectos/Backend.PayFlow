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

builder.Services.AddTransient<ITransaccionesRepository, TransaccionesRepository>();

builder.Services.AddTransient<ISeguimientoTransaccionRepository, SeguimientoTransaccionRepository>();
builder.Services.AddScoped<ISeguimientoTransaccionService, SeguimientoTransaccionService>();

builder.Services.AddTransient<IHistorialValidacionesRepository, HistorialValidacionesRepository>();
builder.Services.AddScoped<IHistorialValidacionesService, HistorialValidacionesService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware y pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
