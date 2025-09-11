using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;

namespace Capgemini.Indentity.Application.Services
{
    public class LoginService : ILoginService
    {


        public Task<LoginResponse> Login(LoginRequest login)
        {
            //LoginResponseSuccess respuesta = new LoginResponseSuccess();


            if (login.Email == "abelcf123@gmail.com" && login.Password == "abejita123_")
            {
                return Task.FromResult<LoginResponse>(new LoginResponseSuccess
            {
                MessageLogin = "Bienvenido",
                HttpStatus = 200,
                Token = "#$%#Fff"
            });
                  
            }
            else
            {
                return Task.FromResult<LoginResponse>(
            new LoginResponseError
            {
                MessageLogin = "Usuario o contraseña incorrecto",
                HttpStatus = 400,
                ErrorType = "NotFound"
            });
            }

             

            //  return Task.FromResult(respuesta);
        }
    }
}
