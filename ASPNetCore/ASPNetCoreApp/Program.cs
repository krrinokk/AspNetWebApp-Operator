using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OperatorContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));


var options = new JsonSerializerOptions()
{
    NumberHandling = JsonNumberHandling.AllowReadingFromString |
     JsonNumberHandling.WriteAsString
};

//builder.Services.AddMvc()
//.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
//.AddJsonOptions(options => {
//    var resolver = options.JsonSerializerOptions.ContractResolver;
//    if (resolver != null)
//        (resolver as DefaultContractResolver).NamingStrategy =
//        null;
//});


// Add services to the container.
builder.Services.AddControllersWithViews()
            // Maintain property names during serialization. See:
            // https://github.com/aspnet/Announcements/issues/194
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Add Kendo UI services to the services container

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
