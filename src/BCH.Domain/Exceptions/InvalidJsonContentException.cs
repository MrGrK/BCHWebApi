using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Domain.Exceptions
{
    internal class InvalidJsonContentException : Exception
    {
        public InvalidJsonContentException(string key)
            : base($"Initial json do not contain specific key: {key}")
        {

        }
    }
}
