using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Core.Services;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtener configuración y cadena de conexión
var _config = builder.Configuration;
var connectionString = _config.GetConnectionString("DeveloperConnection");

// Registrar DbContext
builder.Services.AddDbContext<PayFlowDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar servicios de aplicación
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Controladores y documentación
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
