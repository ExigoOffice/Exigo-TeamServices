using System.ServiceModel;
using System.ServiceModel.Web;

using Exigo.TeamServices.Data.Dto;

namespace Exigo.TeamServices.Service
{
    [ServiceContract]
    public interface IProjectServices
    {
        #region POST

        /// <summary>
        ///     Inserts new records into the Ticket table.
        /// </summary>
        /// <param name="json">A json string of serialized Projects</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Projects/{json}")]
        string PostProjects(string json);

        /// <summary>
        ///     Inserts records into the TicketDetail table.
        /// </summary>
        /// <param name="json">A json string of serialized Project Details</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Detail/{json}")]
        string PostDetail(string json);

        /// <summary>
        ///     Inserts a <see cref="TimeEntry" /> record into the database.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/TimeEntry/{json}")]
        string PostTimeEntry(string json);

        #endregion

        #region UPDATE

        /// <summary>
        ///     Updates an existing project record.
        /// </summary>
        /// <param name="json">A json string of serialized Projects to be updated.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "UPDATE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Projects/{json}")]
        string UpdateProject(string json);

        /// <summary>
        ///     Updates the detial.
        /// </summary>
        /// <param name="json">A json string of serialized Project Details to be updated.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "UPDATE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Details/{json}")]
        string UpdateDetial(string json);

        /// <summary>
        ///     Inserts a <see cref="TimeEntry" /> record into the database.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "UPDATE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/TimeEntry/{json}")]
        string UpdateTimeEntry(string json);

        #endregion

        #region GET

        /// <summary>
        ///     Gets current open projects
        /// </summary>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Projects")]
        string GetNewProjects();

        /// <summary>
        ///     Gets a project based on ProjectId
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Projects/{id}")]
        string GetProject(int id);

        /// <summary>
        ///     Gets a project detail based on the ProjectDetailId.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Details/{id}")]
        string GetProjectDetail(int id);

        /// <summary>
        ///     Gets the details of project by ProjectId.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Projects/Details/{id}")]
        string GetDetailsByParent(int id);

        /// <summary>
        ///     Gets the all the details of projects based on UserId.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Projects/User/{id}")]
        string GetDetailsByUser(int id);

        /// <summary>
        ///     Gets all projects by CompanyId.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Projects/Company/{id}")]
        string GetProjectsByCompany(int id);

        ///// <summary>
        ///// Gets projects based on DepartmentId.
        ///// </summary>
        ///// <param name="id">The Department identifier.</param>
        ///// <returns>System.String.</returns>
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
        //    Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "Projects/Department/{id}")]
        //string GetProjectsByDepartment(int id);

        #endregion
    }
}