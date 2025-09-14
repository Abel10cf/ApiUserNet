using Capgemini.Indentity.Application.Abstractions;
using Capgemini.Indentity.Application.Entities.UserEntity;
using Capgemini.Indentity.Application.Exceptions;
using Capgemini.Indentity.Application.Infrastructure;
using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;

namespace Capgemini.Indentity.Application.Services
{
    public class LoginService : ILoginService
    {

        // Campos de la clase JwtService y IUserRepository
        private readonly JwtService jwtService;
        private readonly IUserRepository userRepository;


        //Inyección de jwt y repository via constructor
        public LoginService(IUserRepository userRepository, JwtService jwtService)
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
        }

        //Inicio del método
        public Task<LoginResponse> Login(LoginRequest login)
        {
            // Validación de nulos o vacíos
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                throw new NullCredentialException("Email o contraseña no pueden estar vacíos");
            }


            // Buscar usuario en el repositorio
            User? user = userRepository.GetUserByCredentials(login.Email, login.Password);

            // Validación de usuario y contraseña
            if (user == null)
            {
                throw new InvalidCredentialException("Usuario o contraseña incorrectos");
            }

            // Validación si usuario está activo
            if (!user.Active)
            {
                throw new InactiveUserException("El usuario existe pero está inactivo");
            }
       

            // Generar JWT
            var token = jwtService.GenerateToken(login.Email);

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