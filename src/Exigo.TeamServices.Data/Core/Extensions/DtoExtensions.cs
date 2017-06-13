using NPoco.fastJSON;

namespace Exigo.TeamServices.Data.Core.Extensions
{
    public static class DtoExtensions
    {
        public static string ToJson<TParameter>(this TParameter parameter)
        {
            return JSON.ToJSON(parameter);
        }
    }
}