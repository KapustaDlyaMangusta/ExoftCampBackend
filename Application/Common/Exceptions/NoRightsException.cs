using System;

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
