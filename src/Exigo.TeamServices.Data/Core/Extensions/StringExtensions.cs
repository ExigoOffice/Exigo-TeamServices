using System.Collections.Generic;

using Exigo.TeamServices.Data.Repository.Base;

using NPoco.fastJSON;

namespace Exigo.TeamServices.Data.Core.Extensions
{
    public static class StringExtensions
    {
        public static TReturn SerializeObject<TReturn>(this string json) where TReturn : IDto
        {
            return JSON.ToObject<TReturn>(json);
        }

        public static IEnumerable<TReturn> SerializeObjectCollection<TReturn>(this string json) where TReturn : IDto
        {
            return (IEnumerable<TReturn>) JSON.ToObject<TReturn>(json);
        }

        public static string Deserialize<TParam>(this TParam parameter) where TParam : IDto
        {
            return JSON.ToJSON(parameter);
        }
    }
}