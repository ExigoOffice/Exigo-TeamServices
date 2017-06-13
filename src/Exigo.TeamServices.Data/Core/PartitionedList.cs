using System.Collections.Generic;

namespace Exigo.TeamServices.Data.Core
{
    public class PartitionedList<T>
    {
        public IList<T> SuccessList { get; set; }
        public IList<T> FailureList { get; set; }
    }
}