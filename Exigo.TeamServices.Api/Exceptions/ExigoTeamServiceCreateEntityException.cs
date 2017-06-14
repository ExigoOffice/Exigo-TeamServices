using System;

namespace Exigo.TeamServices.Api.Exceptions
{
    /// <summary>
    ///     Class ExigoTeamServiceCreateEntityException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ExigoTeamServiceCreateEntityException : Exception
    {
        /// <summary>
        ///     Prevents a default instance of the <see cref="ExigoTeamServiceCreateEntityException" /> class from being
        ///     created.
        /// </summary>
        private ExigoTeamServiceCreateEntityException() {}

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExigoTeamServiceCreateEntityException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExigoTeamServiceCreateEntityException(string message)
            : base(message) {}
    }
}