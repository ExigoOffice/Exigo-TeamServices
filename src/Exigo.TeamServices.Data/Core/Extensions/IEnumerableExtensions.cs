using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using NPoco.Linq;

namespace Exigo.TeamServices.Data.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static HashSet<TReturn> ToHashSet<TReturn>(this IEnumerable<TReturn> enumerable)
        {
            var set = new HashSet<TReturn>();
            foreach (var item in enumerable) set.Add(item);

            return set;
        }

        public static PartitionedList<TReturn> SplitWhere<TReturn>(this IEnumerable<TReturn> enumerable,
                                                                   Expression<Func<TReturn, bool>> partitionExpression)
        {
            var returnArr = new[] {new List<TReturn>(), new List<TReturn>()};
            var lambda = partitionExpression.Compile();
            foreach (var curItem in enumerable)
                returnArr[lambda(curItem)? 0 : 1].Add(curItem);
            

            return new PartitionedList<TReturn> {SuccessList = returnArr[0], FailureList = returnArr[1]};
        }

        public static HashSet<TReturn> ToHashSet<TReturn>(this IQueryProvider<TReturn> enumerable,
                                                          Expression<Func<TReturn, bool>> expression)
        {
            return enumerable.Where(expression).ToEnumerable().ToHashSet();
        }
    }
}