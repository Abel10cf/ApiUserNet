using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Exceptions;
using Capgemini.Indentity.Application.Infrastructure;
using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;

namespace Capgemini.Indentity.Application.Services
{
    public class LoginService : ILoginService
    {


        private const string CorrectEmail = "abelcf123@gmail.com";
        private const string CorrectPassword = "abejita123_";

        private readonly JwtService _jwtService;

        // Inyección de JwtService vía constructor
        public LoginService(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

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

            // Generar JWT
            var token = _jwtService.GenerateToken(login.Email);

            // Login correcto
            return Task.FromResult<LoginResponse>(
                new LoginResponseSuccess
                {
                    MessageLogin = "Login correcto",
                    HttpStatus = 200,
                    Token = token // Se agrega el jwt
                });
        }
    }
}
