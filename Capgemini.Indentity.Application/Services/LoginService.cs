using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Exceptions;
using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;

namespace Capgemini.Indentity.Application.Services
{
    public class LoginService : ILoginService
    {


        private const string CorrectEmail = "abelcf123@gmail.com";
        private const string CorrectPassword = "abejita123_";

        public Task<LoginResponse> Login(LoginRequest login)
        {
            // Validación de nulos o vacíos
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                throw new NullCredentialException("Email o contraseña no pueden estar vacíos");
            }

            // Validación de credenciales
            if (login.Email != CorrectEmail || login.Password != CorrectPassword)
            {
                throw new InvalidCredentialException("Usuario o contraseña incorrectos");
            }

            // Login correcto
            return Task.FromResult<LoginResponse>(
                new LoginResponseSuccess
                {
                    MessageLogin = "Login correcto",
                    HttpStatus = 200,
                    Token = "#$%#Fff" // Aquí luego iría tu JWT
                });
        }
    }
}
