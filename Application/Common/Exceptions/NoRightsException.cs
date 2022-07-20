using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class NoRightsException : Exception
    {
        public NoRightsException(object id)
            : base($"User ({id}) has no authority to do this action.")
        {

        }
    }
}
