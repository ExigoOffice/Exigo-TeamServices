using System;

namespace Exigo.TeamServices.Service
{
    internal class ServiceApiResponse
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string JsonResponseObject { get; set; }
    }
}