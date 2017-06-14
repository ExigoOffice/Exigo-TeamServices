using System;

namespace Exigo.TeamServices.Api.Data
{
    public class ServiceApiResponse
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string JsonResponseObject { get; set; }
    }
}