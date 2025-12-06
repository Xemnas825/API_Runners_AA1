using Microsoft.EntityFrameworkCore;
using RunnerApi.Data;
using RunnerApi.Interfaces;
using RunnerApi.Repository;
using RunnerApi.Services;
using RunnerApi.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RunnersDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<IRunnerRepository, RunnerRepository>();
builder.Services.AddScoped<IRunnerService, RunnerService>();
builder.Services.AddScoped<IGrupoSocialRepository, GrupoSocialRepository>();
builder.Services.AddScoped<IGrupoSocialService, GrupoSocialService>();
builder.Services.AddScoped<IClasificacionRepository, ClasificacionRepository>();
builder.Services.AddScoped<IClasificacionService, ClasificacionService>();
builder.Services.AddScoped<ICarreraRepository, CarreraRepository>();
builder.Services.AddScoped<ICarreraService, CarreraService>();
builder.Services.AddScoped<IRecorridoRepository, RecorridoRepository>();
builder.Services.AddScoped<IRecorridoService, RecorridoService>();
builder.Services.AddScoped<IVentajaRepository, VentajaRepository>();
builder.Services.AddScoped<IVentajaService, VentajaService>();
builder.Services.AddScoped<IRunnerVentajaRepository, RunnerVentajaRepository>();
builder.Services.AddScoped<IRunnerVentajaService, RunnerVentajaService>();




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.Run();
