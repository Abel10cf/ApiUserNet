using Capgemini.identity.WebAPI.Modules;
using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Infrastructure;
using Capgemini.Indentity.Application.Services;


var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Registro de jwt
builder.Services.AddSingleton(new JwtService(
    key: "\"EstaEsUnaClaveSuperLargaDeMasDe32Caracteres123!\"",
    issuer: "CapgeminiIdentityAPI"
));

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
//Se manda a llamar el endpoint
app.AddLoginEndpoints();

app.Run();
