using Capgemini.Indentity.Application.Requests;
using Capgemini.Indentity.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Indentity.Application.Abstractions
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest login);
    }
}
