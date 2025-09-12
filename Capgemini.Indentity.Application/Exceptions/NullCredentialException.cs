using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Indentity.Application.Exceptions
{
    public class NullCredentialException : Exception
    {
        public NullCredentialException(string message) : base(message) { }
    }
}
