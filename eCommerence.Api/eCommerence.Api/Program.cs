using eCommerence.Api.Middlewares;
using eCommerence.Core;
using eCommerence.Core.Mapper;
using eCommerence.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddCore();
builder.Services.AddInfrastructure();

builder.Services.AddControllers().AddJsonOptions(options => 
options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); 
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
