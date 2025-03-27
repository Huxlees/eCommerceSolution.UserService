
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using eCommerceAPI.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.Converters.Add
        (new JsonStringEnumConverter());
    });
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly); //assembly allow to auto map every mapping profile by passing one single profile
//fluent valdator
builder.Services.AddFluentValidationAutoValidation();

//swagger
//add endpoint api explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add cirs services
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
    }
        );
});

//build web app
var app = builder.Build();
// exception
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();
//swagger
app.UseSwagger(); //add enpoint that can server
app.UseSwaggerUI();
app.UseCors();

//Auth
app.UseAuthentication();
app.UseAuthorization();


//controller route
app.MapControllers();

app.Run();
