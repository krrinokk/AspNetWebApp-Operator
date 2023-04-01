using System.Text.Json.Serialization;
using ASPNetCoreApp.Models;
using ASPNetCoreApp.Data;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod();

    });
});



// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<OperatorContext>();
builder.Services.AddDbContext<OperatorContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var operatorContext = scope.ServiceProvider.GetRequiredService<OperatorContext>();
    await OperatorContextSeed.SeedAsync(operatorContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
