using BussniessLogicLayer;
using DataAccessLayer;
using FluentValidation.AspNetCore;
using ProductsService.API.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBussinessLogicLayer();
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseCors();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
