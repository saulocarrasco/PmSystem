using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using PmSystem.Infrastructure.Glue.Cors;
using PmSystem.Infrastructure.Glue.DI;
using PmSystem.Infrastructure.Glue.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DataBaseDiExtension.Configure(builder.Services, builder.Configuration);
RepositoryDiExtension.Configure(builder.Services);
ServiceDiExtension.Configure(builder.Services);
FluentValidatorExtension.Configure(builder.Services);
CorsHandleConfigExtension.Configure(builder.Services, "_myAllowSpecificOrigins");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PmSystem API", Version = "v1" });
});

//Global Validation Handle

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;

    options.InvalidModelStateResponseFactory = c =>
    {
        var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors).Select(p => p.ErrorMessage);
        var result = new
        {
            Title = "Error",
            Errors = errors,
            TraceId = c.HttpContext.TraceIdentifier
        };

        return new BadRequestObjectResult(result);
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PmSystem API V1");
});

app.Run();
