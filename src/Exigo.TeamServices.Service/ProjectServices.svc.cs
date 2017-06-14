using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Exigo.TeamServices.Data.Core;
using Exigo.TeamServices.Data.Core.Extensions;
using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.IoC;
using Exigo.TeamServices.Data.Repository;

using NPoco.fastJSON;

namespace Exigo.TeamServices.Service
{
    public class ProjectServices : IProjectServices
    {
        /// <inheritdoc />
        public string PostProjects(string json)
        {
            var repo = RepositoryContainer.DefaultContainer.FethInstance<IProjectRepository>();
            var projects = json.SerializeObjectCollection<Project>();
            return ExecuteActionInTry(repo.CreateMany, projects);
        }

        /// <inheritdoc />
        public string PostDetail(string json)
        {
            var projectDetailRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectDetailRepository>();
            var detail = json.SerializeObject<ProjectDetail>();

            var timeEntryRepository = RepositoryContainer.DefaultContainer.FethInstance<ITimeEntryRepository>();
            timeEntryRepository.CreateMany(detail.TimeEntries);

            return ExecuteInTry(projectDetailRepository.Create, detail);
        }

        /// <inheritdoc />
        public string PostTimeEntry(string json)
        {
            var repo = RepositoryContainer.DefaultContainer.FethInstance<ITimeEntryRepository>();
            var detail = json.SerializeObject<TimeEntry>();
            return ExecuteInTry(repo.Create, detail);
        }

        /// <inheritdoc />
        public string UpdateProject(string json)
        {
            var projectRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectRepository>();
            return ExecuteActionInTry(projectRepository.UpdateProjectWithDetails, json.SerializeObject<Project>());
        }

        /// <inheritdoc />
        public string UpdateDetial(string json)
        {
            var detailRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectDetailRepository>();
            return ExecuteActionInTry(detailRepository.Update, json.SerializeObject<ProjectDetail>());
        }

        /// <inheritdoc />
        public string UpdateTimeEntry(string json)
        {
            var timeEntryRepository = RepositoryContainer.DefaultContainer.FethInstance<ITimeEntryRepository>();
            var entry = json.SerializeObject<TimeEntry>();
            return ExecuteActionInTry(timeEntryRepository.Update, entry);
        }

        /// <inheritdoc />
        public string GetProject(int id)
        {
            var projectRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectRepository>();
            return ExecuteInTry(projectRepository.FetchById, id, JSON.ToJSON);
        }

        /// <inheritdoc />
        public string GetNewProjects()
        {
            var projectRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectRepository>();
            var results = ExecuteInTry<Project>(projectRepository.Where,
                p => p.ProjectStatusTy == ProjectStatusTy.NewSubmittion, JSON.ToJSON);
            return results.ToJson();
        }

        /// <inheritdoc />
        public string GetProjectDetail(int id)
        {
            var detailRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectDetailRepository>();
            return ExecuteInTry(detailRepository.FetchById, id, JSON.ToJSON);
        }

        /// <inheritdoc />
        public string GetDetailsByParent(int id)
        {
            var projectDetailRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectDetailRepository>();
            return ExecuteInTry<ProjectDetail>(projectDetailRepository.Where, detail => detail.ProjectId == id,
                JSON.ToJSON);
        }

        /// <inheritdoc />
        public string GetDetailsByUser(int id)
        {
            var projectDetailRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectDetailRepository>();
            return ExecuteInTry<ProjectDetail>(projectDetailRepository.Where, detail => detail.EntryUserId == id,
                JSON.ToJSON);
        }

        /// <inheritdoc />
        public string GetProjectsByCompany(int id)
        {
            var projectDetailRepository = RepositoryContainer.DefaultContainer.FethInstance<IProjectDetailRepository>();
            return ExecuteInTry<ProjectDetail>(projectDetailRepository.Where, detail => detail.CompanyId == id,
                JSON.ToJSON);
        }

        private string ExecuteInTry<TParamType, TReturn>(Func<TParamType, TReturn> @delegate, TParamType projects,
                                                         Func<object, string> callback = null)
        {
            object responseObject = null;

            try
            {
                responseObject = @delegate(projects);
                responseObject = callback?.Invoke((TParamType) responseObject);
            }
            catch (Exception ex)
            {
                return new ServiceApiResponse
                {
                    Success = false,
                    JsonResponseObject = (string) responseObject,
                    Exception = ex
                }.ToJson();
            }

            return new ServiceApiResponse {Success = true, JsonResponseObject = (string) responseObject}.ToJson();
        }

        private string ExecuteInTry<TParam>(Func<Expression<Func<TParam, bool>>, IEnumerable<TParam>> @delegate,
                                            Expression<Func<TParam, bool>> func, Func<object, string> callback)
        {
            object responseObject = null;

            try
            {
                responseObject = @delegate(func);
                responseObject = callback(responseObject);
            }
            catch (Exception ex)
            {
                return new ServiceApiResponse
                {
                    Success = false,
                    JsonResponseObject = (responseObject ?? "Response object failed").ToString(),
                    Exception = ex
                }.ToJson();
            }

            return new ServiceApiResponse {Success = true, JsonResponseObject = (string) responseObject}.ToJson();
        }

        private string ExecuteActionInTry<TParamType>(Action<TParamType> @delegate, TParamType projects)
        {
            try { @delegate(projects); }
            catch (Exception ex)
            {
                return new ServiceApiResponse
                {
                    Success = false,
                    Exception = ex
                }.ToJson();
            }

            return new ServiceApiResponse {Success = true}.ToJson();
        }
    }
}