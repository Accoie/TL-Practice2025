using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Foundations;
using WebApi.Infrastructure.Repositories;
using WebApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebApiDbContext>( options =>
{
    options.UseInMemoryDatabase( databaseName: "WebApiDatabase" );
    options.LogTo( Console.WriteLine );
} );
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();


var app = builder.Build();

if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
