using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Exceptions;
using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;


namespace Capgemini.identity.WebAPI.Modules
{
    public static class LoginModule
    {

        public static void AddLoginEndpoints(this WebApplication app)
        {
            app.MapPost("/login", async (LoginRequest request, ILoginService service) =>
            {
                try
                {
                    LoginResponse response = await service.Login(request);
                    return Results.Ok(response);
                }
                //Aquí se maneja la excepción cuando las credenciales van vacías
                catch (NullCredentialException ex)
                {
                    return Results.BadRequest(new LoginResponseError
                    {
                        MessageLogin = ex.Message,
                        HttpStatus = 400,
                        ErrorType = "NullCredential"
                    });
                }
                //Aquí se maneja la excepción cuando las credenciales son incorrectas
                catch (InvalidCredentialException ex)
                {
                    return Results.BadRequest(new LoginResponseError
                    {
                        MessageLogin = ex.Message,
                        HttpStatus = 401,
                        ErrorType = "InvalidCredential"
                    });
                }
                // Aquí se maneja la excepción cuando el usuario esta inactivo
                catch (InactiveUserException ex)
                {
                    return Results.BadRequest(new LoginResponseError
                    {
                        MessageLogin = ex.Message,
                        HttpStatus = 403,
                        ErrorType = "InactiveUser"
                    });
                }
                catch (Exception ex)
                {
                    return Results.Json(new LoginResponseError
                    {
                        MessageLogin = ex.Message,
                        HttpStatus = 500,
                        ErrorType = "InternalServerError"
                    }, statusCode: 500);
                }
            });

        }
    }
}
