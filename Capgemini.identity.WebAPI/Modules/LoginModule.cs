using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Exceptions;
using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;
using Capgemini.Indentity.Application.Services;



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
                    var response = await service.Login(request);
                    return Results.Ok(response);
                }
                catch (NullCredentialException ex)
                {
                    return Results.BadRequest(new LoginResponseError
                    {
                        MessageLogin = ex.Message,
                        HttpStatus = 400,
                        ErrorType = "NullCredential"
                    });
                }
                catch (InvalidCredentialException ex)
                {
                    return Results.BadRequest(new LoginResponseError
                    {
                        MessageLogin = ex.Message,
                        HttpStatus = 401,
                        ErrorType = "InvalidCredential"
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
