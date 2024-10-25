using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SysFactuApi.Domain.Interfaces;
using SysFactuApi.Domain.Services;
using SysFactuApi.CrossCutting.Repositories.Reporting;
using SysFactuApi;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


// Agregar servicios a la colección de servicios.
builder.Services.AddControllers();
builder.Services.AddScoped<IReportingManager, ReportingRepository>(); // Asegúrate de que ReportingManager esté implementado correctamente
builder.Services.AddScoped<Services>();

// Configurar carga de `appsettings.json`
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Mapear `GlobalVariables` desde la configuración
builder.Services.Configure<GlobalVariables>(builder.Configuration.GetSection("GlobalVariables"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<GlobalVariables>>().Value);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200") // Cambia esto por el origen de tu frontend
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// Aplicar la política de CORS
app.UseCors("AllowSpecificOrigin");


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();