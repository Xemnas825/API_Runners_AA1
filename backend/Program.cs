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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.Run();
