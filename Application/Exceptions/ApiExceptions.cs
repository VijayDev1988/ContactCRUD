using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ApiExceptions : Exception
    {
        public ApiExceptions() : base() { }

        public ApiExceptions(string message) : base(message) { }

        public ApiExceptions(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
