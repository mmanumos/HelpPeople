using AutoMapper;
using HelpPeople.AutoMapper;
using HelpPeople.Implementation;
using HelpPeople.Implementation.Contract;
using HelpPeople.Models;
using HelpPeople.Service;
using HelpPeople.Service.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Configuración de AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new HelpPeopleProfile()); 
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//Cors - Definición de cliente que tienen permiso de acceder
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de dependencias
builder.Services.AddDbContext<HelpPeopleContext>();
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPersonaImplementation, PersonaImplementation>();
builder.Services.AddScoped<IReadCvsService, ReadCvsService>();
builder.Services.AddScoped<IReadCvsImplementation, ReadCsvImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
