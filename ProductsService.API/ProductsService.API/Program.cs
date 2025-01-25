using FluentValidation.AspNetCore;
using eCommerce.ProductsMicroService.API.APIEndpoints;
using System.Text.Json.Serialization;
using DataAccessLayer;
using BussniessLogicLayer;
using ProductsService.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

//Add DAL and BLL services
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBussinessLogicLayer();

builder.Services.AddControllers();
builder.Services.AddAuthorization();

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();

//Add model binder to read values from JSON to enum
builder.Services.ConfigureHttpJsonOptions(options => { 
  options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapProductAPIEndpoints();

app.Run();
