using System;

namespace Exigo.TeamServices.Api.DependancyInjection
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(string message)
            : base(message) {}
    }
}