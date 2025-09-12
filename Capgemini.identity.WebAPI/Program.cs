using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Services;
using Capgemini.identity.WebAPI.Modules;


var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Aqu� se hace la inyecci�n de dependencias para registrar que implementaci�n se dar� cuando
//se pida un ILoginService
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();



// Activar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Es el body de la peticion

app.AddLoginEndpoints();

app.Run();
