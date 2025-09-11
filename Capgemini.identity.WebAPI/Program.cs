using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;
using Capgemini.Indentity.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// Activar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/login", async (LoginRequest request, ILoginService service) =>
{
    LoginResponse response = await service.Login(request);

    return response.HttpStatus switch
    {
        200 => Results.Ok(response),
        400 => Results.BadRequest(response),
        500 => Results.Json(response, statusCode: 500),
        _ => Results.BadRequest(response)
    };
});

app.Run();
