using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Indentity.Application.Responses
{
    public class LoginResponseSuccess : LoginResponse
    {
        public string Token {  get; init; }
    }
}
