using ApiListaCompras.AutoMappers;
using ApiListaCompras.DTOs;
using ApiListaCompras.Models;
using ApiListaCompras.Repository;
using ApiListaCompras.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CAPA DE SERVICIOS
builder.Services.AddKeyedScoped<ICommonService<ItemDTO>, ItemService>("ItemService");

// REPOSITORIOS
builder.Services.AddScoped<IRepository<Item>, ItemRepository>();

// ENTITY FRAMEWORK
builder.Services.AddDbContext<ListaComprasDbContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
});

//MAPPERS
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173", 
                                "http://localhost:3000",
                                "http://ec2-18-232-157-87.compute-1.amazonaws.com:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

// TODO ANTES DE ESTO QUE ES EL BUILD
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
