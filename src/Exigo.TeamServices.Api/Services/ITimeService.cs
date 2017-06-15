using Exigo.TeamServices.Api.Base;
using Exigo.TeamServices.Api.Handlers;
using Exigo.TeamServices.Data.Dto;

namespace Exigo.TeamServices.Api.Services
{
    public interface ITimeService : ICrudService<TimeEntry>, IRestApiService {}

    /// <summary>
    ///     Class TimeService.
    /// </summary>
    /// <seealso cref="CrudService{T}.Data.Models.Time}" />
    /// <seealso cref="ITimeService" />
    public class TimeService : CrudService<TimeEntry>, ITimeService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeService" /> class.
        /// </summary>
        /// <param name="requestHandler">The request handler.</param>
        public TimeService(IServiceRequestHandler requestHandler) : base(requestHandler) {}

        /// <summary>
        ///     Gets the entity URL.
        /// </summary>
        /// <value>The entity URL.</value>
        public override string EntityUrl { get; } = "TimeEntries";
    }
}