using DB;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Conectar con la BD
builder.Services.AddDbContext<PosFarmaciaContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PosFarmaciaConeccion"));
});

//Repository
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<DetalleVentaRepository>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<VentaRepository>();



//Service
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<DetalleVentaService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<VentaService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PosFarmaciaContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
