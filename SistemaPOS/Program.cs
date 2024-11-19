using Microsoft.EntityFrameworkCore;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Data;
using SistemaPOS.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddScoped<ProductoRepository, ProductoRepositoryImpl>();
builder.Services.AddScoped<ProductoService>();

builder.Services.AddScoped<ClienteRepository, ClienteRepositoryImpl>();
builder.Services.AddScoped<ClienteService>();

builder.Services.AddScoped<ConvenioRepository, ConvenioRepositoryImpl>();
builder.Services.AddScoped<ConvenioService>();

builder.Services.AddScoped<MedioPagoRepository, MedioPagoRepositoryImpl>();
builder.Services.AddScoped<MedioPagoService>();

builder.Services.AddScoped<PedidoRepository, PedidoRepositoryImpl>();
builder.Services.AddScoped<PedidoService>();

builder.Services.AddScoped<UsuarioRepository, UsuarioRepositoryImpl>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<FacturaRepository, FacturaRepositoryImpl>();
builder.Services.AddScoped<FacturaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
