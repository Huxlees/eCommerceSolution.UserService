
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using eCommerceAPI.Middlewares;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.Converters.Add
        (new JsonStringEnumConverter());
    });
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
//build web app
var app = builder.Build();
// exception
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();
//Auth
app.UseAuthentication();
app.UseAuthorization();
//controller route
app.MapControllers();

app.Run();
