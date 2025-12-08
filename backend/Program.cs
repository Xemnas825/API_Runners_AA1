using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RunnerApi.Data;
using RunnerApi.Interfaces;
using RunnerApi.Repository;
using RunnerApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RunnersDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("RunnersDB"), //
        new MySqlServerVersion(new Version(8, 0, 44)), //
        mySqlOptions => mySqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    )
    .UseSnakeCaseNamingConvention()
);

builder.Services.AddScoped<IRunnerRepository, RunnerRepository>();
builder.Services.AddScoped<IRunnerService, RunnerService>();
builder.Services.AddScoped<IGrupoSocialRepository, GrupoSocialRepository>();
builder.Services.AddScoped<IGrupoSocialService, GrupoSocialService>();
builder.Services.AddScoped<IClasificacionRepository, ClasificacionRepository>();
builder.Services.AddScoped<IClasificacionService, ClasificacionService>();
builder.Services.AddScoped<IRecorridoRepository, RecorridoRepository>();
builder.Services.AddScoped<IRecorridoService, RecorridoService>();
builder.Services.AddScoped<IVentajaRepository, VentajaRepository>();
builder.Services.AddScoped<IVentajaService, VentajaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Unhandled exception: " + ex);
        throw;
    }
});

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
