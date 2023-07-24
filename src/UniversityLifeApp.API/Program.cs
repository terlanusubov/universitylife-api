using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Serilog;
using UniversityLifeApp.Infrastructure;
using Microsoft.Extensions.Hosting;
using UniversityLifeApp.Application;
using UniversityLifeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using UniversityLifeApp.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);




//versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});



builder.Services.AddApplication(builder.Configuration);


builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpContextAccessor();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var provider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

    var environment = builder.Services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();



    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerDoc(description.GroupName, new OpenApiInfo
        {
            Title = $"University Life API: ({environment.EnvironmentName})",
            Version = description.ApiVersion.ToString(),
            Description = "High Result Tech Team  -> University Life API",
            Contact = new OpenApiContact
            {
                Name = "High Result Tech",
                Email = "tarlan.usubov@hra.az",
                Url = new Uri("https://edu.hra.az/"),
            },
        });
    }
    c.CustomSchemaIds(a => a.FullName);
}
);


var app = builder.Build();

app.UseMiddleware<InputLoggingMiddleware>();
app.UseMiddleware<OutputLoggingMiddleware>();

app.UseHttpLogging();

app.UseSwagger();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwaggerUI(c =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
    {
        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        c.RoutePrefix = string.Empty;
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
